
using System;
using System.Collections;
using UnityEngine;

public class PlayerPhysicsManager : ICharacterPhysicsManagerImpl
{
    public IColliderService Collider{get; private set; }

    public IRigidbodyService Rigidbody{get; private set;}
    private float CollisionCheckRange;

    private float BottomOffset;
    private IRaycastService Raycast;

    [SerializeField]
    private bool IsJumping = false;

    public PlayerPhysicsManager(
        ref IColliderService collider,
        ref IRigidbodyService rigidbody,
        ref float collisionCheckRange,
        ref float bottomOffset,
        ref IRaycastService raycast)
    {
        Collider = collider;
        Rigidbody = rigidbody;
        CollisionCheckRange = collisionCheckRange;
        BottomOffset = bottomOffset;
        Raycast = raycast;
    }

    public bool IsGrounded(Vector3 playerPosition)
    {
        Vector3 playerBottom = playerPosition - GetColliderYBounds(BottomOffset);
        return  Raycast.HasHitSomething(playerBottom, Vector3.down, CollisionCheckRange);
    }

    private Vector3 GetColliderYBounds(float offset = 0.01f)
	{
		return new Vector3(0, Collider.GetBounds().extents.y - offset, 0);
	}

    public void Jump( float jumpStrength, Vector3 playerPosition)
    {
        if(IsGrounded(playerPosition) && !IsJumping)
        {
            Debug.Log("jumping");
            Rigidbody.AddForce(new Vector3(0,jumpStrength, 0), ForceMode.Impulse);
            IsJumping = true;
        }
    }
    public void SetGravityEnabled(bool enabled)
    {
        Rigidbody.useGravity = enabled;
    }

    public void OnCollision(GameObject collidedObject, Vector3 playerPosition)
    {
        IsJumping = !IsGrounded(playerPosition);
    }
}