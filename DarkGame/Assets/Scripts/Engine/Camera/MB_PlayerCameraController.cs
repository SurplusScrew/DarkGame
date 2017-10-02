using System;
using System.Collections;
using UnityEngine;

public class MB_PlayerCameraController : MonoBehaviour, ICameraController
{
	public float RotationSpeed = 1f;
	public float XLimit = 80f;
	public float CameraLerpSpeed = 0.8f;

	private PlayerCameraController Controller;

	public void Awake()
	{
		Controller = new PlayerCameraController(XLimit: ref XLimit, RotationSpeed: ref RotationSpeed);
	}

    public GameObject Camera
    {
        get;

        set;
    }

    public Vector3 GetForwardVector()
    {
		return transform.forward;
    }

    public void Rotate(Vector2 moveVector)
    {
		Camera.transform.rotation = Controller.RotateBehindPlayer(Camera.transform.rotation, moveVector);
    }

	public void ChaseTarget(GameObject target)
	{
		StartCoroutine(Chase(target));
	}

	private IEnumerator Chase(GameObject target)
	{
		while(target)
		{
			Vector3 CamPos = Camera.transform.position;
			Vector3 TargetPos = target.transform.position;
			Camera.transform.position = Controller.CalculateNewCameraPosition(CamPos, TargetPos, CameraLerpSpeed);
			yield return new WaitForFixedUpdate();
		}
	}
}

public class PlayerCameraController
{
	public float RotationSpeed;
	public float XLimit;

	public PlayerCameraController(ref float RotationSpeed, ref float XLimit)
	{
		this.RotationSpeed = RotationSpeed;
		this.XLimit = XLimit;
	}

    public Quaternion RotateBehindPlayer(Quaternion currentAngle, Vector2 moveVector)
    {
		return Quaternion.Euler(GetLimitedCameraRotation(currentAngle, moveVector));
    }

    public Vector3 GetLimitedCameraRotation(Quaternion currentAngle, Vector2 moveVector)
    {
        Vector3 intendedAngle = currentAngle.eulerAngles + (new Vector3(moveVector.y, moveVector.x, 0) * RotationSpeed);
		return LimitAngle(intendedAngle);
    }

	public Vector3 LimitAngle(Vector3 angleToLimit)
	{
		if(angleToLimit.x > XLimit && angleToLimit.x <  360 - XLimit)
		{
			if (angleToLimit.x > 180)
			{
				angleToLimit.x = 360-XLimit;
			}
			else
			{
				angleToLimit.x = XLimit;
			}
		}
		return angleToLimit;
	}

    public Vector3 CalculateNewCameraPosition(Vector3 startPosition, Vector3 targetPosition, float lerpSpeed)
    {
        return Vector3.Lerp(startPosition, targetPosition, lerpSpeed);
    }
}
