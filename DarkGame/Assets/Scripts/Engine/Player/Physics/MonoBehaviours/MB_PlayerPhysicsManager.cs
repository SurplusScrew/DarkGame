
using System;
using System.Collections;
using UnityEngine;

public class MB_PlayerPhysicsManager : MonoBehaviour, ICharacterPhysicsManager
{

    private IRigidbodyService Rigidbody;

    private IColliderService Collider;

    private PlayerPhysicsManager physicsManager;

    private IRaycastService Raycast;

    [SerializeField]
    public float CollisionCheckRange = 0.25f;
    public float BottomOffset = 0.01f;

    public void Awake()
    {
        Collider = new UnityColliderService(GetComponentInChildren<Collider>());
        Rigidbody = new UnityRigidbodyService(GetComponentInChildren<Rigidbody>());
        Raycast = new UnityRaycastService();

        physicsManager = new PlayerPhysicsManager(ref Collider, ref Rigidbody,  ref CollisionCheckRange, ref Raycast);

    }

    public void Update()
    {
        Rigidbody.useGravity = !IsGrounded();
    }

    public void Jump( float jumpStrength)
    {
        physicsManager.Jump(jumpStrength, transform.position);
    }
    public void SetGravityEnabled(bool enabled)
    {
        physicsManager.SetGravityEnabled(enabled);
    }

    public bool IsGrounded()
    {
        return physicsManager.IsGrounded(transform.position);
    }

    public void SetVelocity(Vector3 velocity)
    {
        Rigidbody.velocity = velocity;
    }

    public Vector3 GetVelocity()
    {
        return Rigidbody.velocity;
    }
}