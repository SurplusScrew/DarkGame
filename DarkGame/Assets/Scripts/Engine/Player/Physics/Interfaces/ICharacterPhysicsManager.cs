using UnityEngine;

public interface ICharacterPhysicsManager
{
    bool IsGrounded();

    void Jump(float jumpStrength);

    void SetGravityEnabled(bool enabled);

    void SetVelocity(Vector3 velocity);

    Vector3 GetVelocity();

}

public interface ICharacterPhysicsManagerImpl
{
    bool IsGrounded(Vector3 position);

    void Jump(float jumpStrength, Vector3 position);

    void SetGravityEnabled(bool enabled);

    void OnCollision(GameObject collidedObject, Vector3 playerPosition);

    IRigidbodyService Rigidbody {get;}
    IColliderService Collider {get;}
}