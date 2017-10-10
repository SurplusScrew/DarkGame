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

    public void Rotate(Vector2 cameraInput)
    {
		Camera.transform.rotation = Controller.Rotate(Camera.transform.rotation, cameraInput);
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
