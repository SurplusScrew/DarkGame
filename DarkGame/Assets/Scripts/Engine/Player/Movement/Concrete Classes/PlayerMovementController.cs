using System;
using UnityEngine;

public class PlayerMovementController : IMovementControllerImpl
{
    public float Acceleration{ get; protected set;}
	public float Deceleration{ get; protected set;}
	public float MaxSpeed {get; protected set;}
    public PlayerMovementController(ref float Acceleration, ref float Deceleration, ref float MaxSpeed )
    {
        this.Acceleration = Acceleration;
        this.Deceleration = Deceleration;
        this.MaxSpeed = MaxSpeed;
    }

    public Vector3 Move(Vector2 moveVector, Vector3 lookVectorForward, Vector3 lookVectorRight, Vector3 initialVelocity)
    {
		Vector2 RotatedLookVector = CalculateRotatedLookVector(
			moveVector,
			UtilMaths.V3toV2_XZ(lookVectorForward),
			UtilMaths.V3toV2_XZ(lookVectorRight));

		Vector3 UpdatedVel = UpdatedVelocity(RotatedLookVector, initialVelocity);
		return UpdatedVel;
    }

	public Quaternion UpdateModelRotation(Vector3 lookVector, Vector3 forward, float currentMovementSpeed)
	{
		//Rotate faster if you're already moving
		float speed = currentMovementSpeed / MaxSpeed;
		float step = speed * Time.deltaTime;

		Vector3 newDir = Vector3.RotateTowards(forward, lookVector, step, 0.0F);

		return Quaternion.LookRotation(newDir);
	}

	private Vector2 CalculateRotatedLookVector(Vector2 moveVector, Vector2 CamForwardVector, Vector2 CamRightVector)
	{
		return new Vector2(
			moveVector.y * CamForwardVector.x + moveVector.x * CamRightVector.x ,
			moveVector.y * CamForwardVector.y + moveVector.x * CamRightVector.y
		);
	}

	private Vector3 UpdatedVelocity( Vector2 moveVector, Vector3 currentVelocity )
	{
		Vector3 AccelerationVector = Vector3.zero;

		AccelerationVector.x = GetAcceleration(moveVector.x, currentVelocity.x);
		AccelerationVector.z = GetAcceleration(moveVector.y, currentVelocity.z);

		return LimitedVelocity(currentVelocity + AccelerationVector);
	}

    private float GetAcceleration(float move, float currentVelocity)
    {
        if (!Mathf.Approximately(0, move))
		{
			return move * Acceleration;
		}
		else if(!Mathf.Approximately( 0, currentVelocity ))
		{
			return Decelerate(currentVelocity);
		}
		return 0;
    }

	private float Decelerate(float currentVelocity)
	{
		float decel = Deceleration;
		if(Mathf.Abs(currentVelocity) < Deceleration)
		{
			decel = currentVelocity;
		}
		return currentVelocity > 0 ? - decel : decel;
	}

    private Vector3 LimitedVelocity(Vector3 currentVelocity)
	{
		Vector2 flatVelocity = UtilMaths.V3toV2_XZ(currentVelocity);

		flatVelocity = GetLimitedLongitudinalVelocity(flatVelocity);

		return UtilMaths.V2toV3_XZ(flatVelocity, currentVelocity.y);
	}

	private Vector2 GetLimitedLongitudinalVelocity(Vector2 velocity)
	{
		if( velocity.magnitude > MaxSpeed )
		{
			velocity *= (MaxSpeed/velocity.magnitude);
		}

		return velocity;
	}
}