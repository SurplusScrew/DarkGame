using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour, IMovementController
{
	[SerializeField]
	private float Acceleration = 0.1f;


	[SerializeField]
	public float MaxSpeed = 5f;

	Rigidbody rigidbody;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
    public void Jump(float jumpStrength)
    {
		rigidbody.AddRelativeForce(new Vector3(0,jumpStrength, 0));
    }

    public void Move(Vector3 moveVector)
    {

		rigidbody.velocity = GetLimitedVelocity(GetUpdatedVelocity(moveVector));
    }

	private Vector3 GetUpdatedVelocity( Vector3 moveVector )
	{
		return rigidbody.velocity + (moveVector * Acceleration);
	}

	private Vector3 GetLimitedVelocity(Vector3 currentVelocity)
	{
		Vector2 flatVelocity = limitFlatVelocity(currentVelocity);
		currentVelocity.x = flatVelocity.x;
		currentVelocity.z = flatVelocity.y;
		return currentVelocity;
	}

	private Vector2 limitFlatVelocity(Vector3 velocity)
	{
		Vector2 flatVelocity = new Vector2(velocity.x, velocity.z);
		if(flatVelocity.magnitude > MaxSpeed)
		{
			flatVelocity *= (MaxSpeed/flatVelocity.magnitude);
		}
		return flatVelocity;
	}

    public float GetAcceleration()
    {
        return Acceleration;
    }
}
