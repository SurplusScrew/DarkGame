using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IMovementController
{
	[SerializeField]
	public float Acceleration = 0.5f;
	public float Deceleration = 0.5f;

	[SerializeField]
	public float MaxSpeed = 7f;

	private IRigidbodyPhysicsManager physicsManager;
	private new Rigidbody rigidbody;

    public GameObject Player
    {
        get; set;
    }

    private void Start()
	{
		physicsManager = Player.AddComponent<PlayerPhysicsManager>();
		rigidbody = Player.GetComponent<Rigidbody>();
	}
    public void Jump(float jumpStrength)
    {
		physicsManager.Jump(jumpStrength);

    }

    public void Move(Vector2 moveVector, Vector3 lookVector)
    {
		rigidbody.velocity = GetUpdatedVelocity(CalculateRotatedLookVector(moveVector, new Vector2(lookVector.x, lookVector.z)));

		Vector3 flatLookVector = new Vector3(lookVector.x, 0, lookVector.z);

		Look(flatLookVector);

		Debug.DrawRay(Player.transform.position, flatLookVector, Color.red, 10f);// * (flatLookVector.magnitude/MaxSpeed));
    }


	public void Look(Vector3 lookVector)
	{
		float speed = rigidbody.velocity.magnitude / MaxSpeed;
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(Player.transform.forward, lookVector, step, 0.0F);
		Debug.DrawRay(Player.transform.position, newDir, Color.red);
		Player.transform.rotation = Quaternion.LookRotation(newDir);
	}

	private Vector2 CalculateRotatedLookVector(Vector2 moveVector, Vector2 LookVector)
	{
		return new Vector2(
			moveVector.x * Mathf.Cos(LookVector.x) + moveVector.y * Mathf.Sin(LookVector.x),
			moveVector.x * Mathf.Cos(LookVector.y) + moveVector.y * Mathf.Sin(LookVector.y));
	}



	private Vector3 GetUpdatedVelocity( Vector2 moveVector )
	{

		//Debug.Log("Move Vector: " + moveVector);
		Vector3 LimitedVelocity = GetLimitedVelocity(rigidbody.velocity + (new Vector3(moveVector.x, 0, moveVector.y) * Acceleration));
		Vector3 RotatedLimitedVelocity = new Vector3(LimitedVelocity.x, LimitedVelocity.y, LimitedVelocity.z);
		//Debug.Log("New movement: " + LimitedVelocity);
		return RotatedLimitedVelocity;
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
			Debug.Log("Flat Velocity: " + flatVelocity);
		}
		return flatVelocity;
	}

	private void
    public float GetAcceleration()
    {
        return Acceleration;
    }
}
