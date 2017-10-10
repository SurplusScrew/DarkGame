using System;
using UnityEngine;

public class MB_PlayerMovementController : MonoBehaviour, IMovementController
{
	public float Acceleration = 0.5f;
	public float Deceleration = 0.5f;
	public float MaxSpeed = 7f;

	private IRigidbodyPhysicsManager physicsManager;
	private new Rigidbody rigidbody;

    public GameObject Player
    {
        get; set;
    }

	PlayerMovementController MovementController;

    private void Start()
	{
		MovementController = new PlayerMovementController(ref Acceleration, ref Deceleration, ref MaxSpeed);
		physicsManager = gameObject.AddComponent<PlayerPhysicsManager>();
		rigidbody = GetComponent<Rigidbody>();
	}

    public void Move(Vector2 moveVector, Transform camera)
    {
		rigidbody.velocity = MovementController.Move(
			moveVector,
			camera.forward,
			camera.right,
			rigidbody.velocity);
		transform.rotation =	MovementController.UpdateModelRotation(
			camera.forward,
			transform.forward,
			rigidbody.velocity.magnitude
		);
    }
}
