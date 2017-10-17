
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Physics
{
    public class Test_PlayerPhysicsManager
    {
        PlayerPhysicsManager playerPhysicsManager;
        private IColliderService collider;
        private IRigidbodyService rigidbody;
        private IRaycastService Raycast;
        private float collisionCheckRange;


        [SetUp]
        public void setup()
        {
            collider = Substitute.For<IColliderService>();
            collider.bounds.Returns(new Bounds(Vector3.zero, new Vector3(1f,1f,1f)));

            Raycast = Substitute.For<IRaycastService>();


            playerPhysicsManager = new PlayerPhysicsManager(ref collider, ref rigidbody, ref collisionCheckRange, ref Raycast);
        }

        [Test]
        public void Jumping_withJumpStrength0_YPositionDoesNotChange()
        {
            Raycast.HasHitSomething(Vector3.zero, Vector3.zero, 0).Returns(true);
            playerPhysicsManager.Jump(0,Vector3.zero);
            Assert.AreEqual(rigidbody.velocity, Vector3.zero);
        }
        [Test]
        public void Jumping_withJumpStrength10_YPositionChanges()
        {
            Raycast.HasHitSomething(Vector3.zero, Vector3.zero, 0).Returns(true);
            playerPhysicsManager.Jump(10,Vector3.zero);
            Assert.AreEqual(rigidbody.velocity, new Vector3(0,10,0));
        }


 /*public void Jump( float jumpStrength, Vector3 playerPosition)
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
     public bool IsGrounded(Vector3 playerPosition)
    {
        Vector3 playerBottom = playerPosition - GetColliderYBounds();

        //Wrap this in a service object to enable ease of testing.
        //---
        RaycastHit hit;
        Ray ray = new Ray(playerBottom, Vector3.down);
        Debug.DrawRay(playerBottom, Vector3.down, Color.red, 4f);
		Physics.Raycast(ray, out hit, CollisionCheckRange);

        bool IsGrounded = hit.collider != null;
        //----

        return IsGrounded;

    }*/
    }

    public class TestRigidbodyService
    {
        public bool useGravity
        {
            get;set;
        }

        public Vector3 velocity
        {
            get;set;
        }

        public TestRigidbodyService()
        {
            velocity = Vector3.zero;
            useGravity = true;
        }
        public void AddForce(Vector3 force, ForceMode ForceMode)
        {
            velocity += force;
        }
    }
}
