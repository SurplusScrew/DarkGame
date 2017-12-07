
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
        private float CollisionCheckRange;
        private float BottomOffset;


        [SetUp]
        public void setup()
        {
            collider = Substitute.For<IColliderService>();
            collider.GetBounds().Returns(new Bounds(Vector3.zero, new Vector3(1f,1f,1f)));

            Raycast = Substitute.For<IRaycastService>();

            rigidbody = new TestRigidbodyService();

            playerPhysicsManager = new PlayerPhysicsManager(ref collider, ref rigidbody, ref BottomOffset, ref CollisionCheckRange, ref Raycast);
        }

        [Test]
        public void Jumping_withJumpStrength0_YPositionDoesNotChange()
        {
            Raycast.HasHitSomething(Vector3.zero, Vector3.zero, 0).ReturnsForAnyArgs(true);
            playerPhysicsManager.Jump(0,Vector3.zero);
            Assert.AreEqual(rigidbody.velocity, Vector3.zero);
        }
        [Test]
        public void Jumping_withJumpStrength10_YPositionChanges()
        {
            Raycast.HasHitSomething(Vector3.zero, Vector3.zero, 0).ReturnsForAnyArgs(true);
            playerPhysicsManager.Jump(10,Vector3.zero);
            Assert.AreEqual(new Vector3(0,10,0), rigidbody.velocity);
        }

        [Test]
        public void Jumping_withJumpStrength10AndNotOnGround_YPositionDoesNotChange()
        {
            Raycast.HasHitSomething(Vector3.zero, Vector3.zero, 0).ReturnsForAnyArgs(false);
            playerPhysicsManager.Jump(10,Vector3.zero);
            Assert.AreNotEqual(new Vector3(0,10,0), rigidbody.velocity);
        }

    }

    public class TestRigidbodyService : IRigidbodyService
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
