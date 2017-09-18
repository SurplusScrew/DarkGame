public interface IRigidbodyPhysicsManager
{
    void SetGravityEnabled(bool enabled);

    bool IsGrounded();

    void Jump(float jumpStrength);
}