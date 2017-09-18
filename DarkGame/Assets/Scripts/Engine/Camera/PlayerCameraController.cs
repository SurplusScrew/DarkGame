using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour, ICameraController
{
	public float RotationSpeed = 1f;
	public float XLimit = 80f;
	public float CameraLerpSpeed = 0.8f;

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
		Camera.transform.rotation = Quaternion.Euler(GetLimitedCameraRotation(moveVector));
    }

    private Vector3 GetLimitedCameraRotation(Vector2 moveVector)
    {
        Vector3 intendedAngle = Camera.transform.rotation.eulerAngles +
								(new Vector3(moveVector.y, moveVector.x, 0) * RotationSpeed);
		return LimitAngle(intendedAngle);
    }

	private Vector3 LimitAngle(Vector3 angleToLimit)
	{
		Vector2 offsetAngleToLimit = new Vector2(angleToLimit.x + 180f, angleToLimit.y + 180f);
		float offsetXLimit = XLimit;

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
			Camera.transform.position = Vector3.Lerp(CamPos, TargetPos, CameraLerpSpeed);
			yield return null;
		}
	}
}
