
using System;
using System.Collections;
using UnityEngine;

public class PlayerPhysicsManager : ICharacterPhysicsManagerImpl
{
    public IColliderService Collider{get; private set; }

    public IRigidbodyService Rigidbody{get; private set;}
    private float CollisionCheckRange;
    private IRaycastService Raycast;

    public PlayerPhysicsManager(
        ref IColliderService collider,
        ref IRigidbodyService rigidbody,
        ref float collisionCheckRange,
        ref IRaycastService raycast)
    {
        Collider = collider;
        Rigidbody = rigidbody;
        CollisionCheckRange = collisionCheckRange;
        Raycast = raycast;
    }

    public bool IsGrounded(Vector3 playerPosition)
    {
        Vector3 playerBottom = playerPosition - GetColliderYBounds();

        return Raycast.HasHitSomething(playerBottom, Vector3.down, CollisionCheckRange);

    }

    private Vector3 GetColliderYBounds(float offset = 0.01f)
	{
		return new Vector3(0, Collider.bounds.extents.y - offset, 0);
	}

    public void Jump( float jumpStrength, Vector3 playerPosition)
    {
        if(IsGrounded(playerPosition))
        {
            Rigidbody.AddForce(new Vector3(0,jumpStrength, 0), ForceMode.Impulse);
        }
    }
    public void SetGravityEnabled(bool enabled)
    {
        Rigidbody.useGravity = enabled;
    }
}