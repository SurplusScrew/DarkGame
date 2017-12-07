
using System;
using System.Collections;
using UnityEngine;

public class MB_PlayerPhysicsManager : MonoBehaviour, ICharacterPhysicsManager
{

    private IRigidbodyService Rigidbody;

    private IColliderService Collider;

    private ICharacterPhysicsManagerImpl PhysicsManager;

    private IRaycastService Raycast;

    [SerializeField]
    public float CollisionCheckRange = 0.25f;
    public float BottomOffset = 0.01f;

    public void Awake()
    {
        Collider = new UnityColliderService(GetComponentInChildren<Collider>());
        Rigidbody = new UnityRigidbodyService(GetComponentInChildren<Rigidbody>());
        Raycast = new UnityRaycastService();

        PhysicsManager = new PlayerPhysicsManager(
            ref Collider,
            ref Rigidbody,
            ref CollisionCheckRange,
            ref BottomOffset,
            ref Raycast);

    }

    public void FixedUpdate()
    {
        Rigidbody.useGravity = !IsGrounded();
    }

    public void Jump( float jumpStrength)
    {
        PhysicsManager.Jump(jumpStrength, transform.position);
    }
    public void SetGravityEnabled(bool enabled)
    {
        PhysicsManager.SetGravityEnabled(enabled);
    }

    public bool IsGrounded()
    {
        return PhysicsManager.IsGrounded(transform.position);
    }

    public void SetVelocity(Vector3 velocity)
    {
        Rigidbody.velocity = velocity;
    }

    public Vector3 GetVelocity()
    {
        return Rigidbody.velocity;
    }

    public void OnCollisionEnter(Collision CollisionObject)
    {
        PhysicsManager.OnCollision(CollisionObject.gameObject, transform.position);
    }
}