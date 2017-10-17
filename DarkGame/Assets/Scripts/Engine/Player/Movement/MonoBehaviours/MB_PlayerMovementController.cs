using System;
using UnityEngine;

public class MB_PlayerMovementController : MonoBehaviour, IMovementController
{
	public float Acceleration = 0.5f;
	public float Deceleration = 0.5f;
	public float MaxSpeed = 7f;

	IMovementControllerImpl MovementController;

    private void Start()
	{
		MovementController = new PlayerMovementController(ref Acceleration, ref Deceleration, ref MaxSpeed);
	}

    public Vector3 Move(Vector2 moveVector, Transform camera, Vector3 initialVelocity)
    {
		return MovementController.Move(
			moveVector,
			camera.forward,
			camera.right,
			initialVelocity);
	}

	public Quaternion Rotate(Transform camera, float velocityMagnitude, bool ThreeDimensional = false)
	{
		Vector3 euler =  MovementController.UpdateModelRotation(
			camera.forward,
			transform.forward,
			velocityMagnitude
		).eulerAngles;
		if(!ThreeDimensional)
		{
			euler.x = 0;
		}
		return Quaternion.Euler(euler);
    }
}
