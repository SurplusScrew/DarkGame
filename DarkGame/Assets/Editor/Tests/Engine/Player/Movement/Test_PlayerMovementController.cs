
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Movement
{
    public class Test_PlayerMovementController
    {
        PlayerMovementController playerMovementController;
        float Acceleration = 0.1f;
        float Deceleration = 0.1f;
        float MaxSpeed  = 1f;

        [SetUp]
        public void setup()
        {
            playerMovementController = new PlayerMovementController(ref Acceleration, ref Deceleration, ref MaxSpeed );
        }

        [Test]
        public void MoveVelocity_FromStandingStill_ShouldAdvanceByAcceleration()
        {
            Assert.AreEqual( Vector3.forward * Acceleration,

                playerMovementController.Move(
                    new Vector2(0,1f),
                    Vector3.forward,
                    Vector3.right,
                    Vector3.zero
                    )
                );
        }

        [Test]
        public void MoveVelocity_FromMaxVelocity_ShouldNotExceedMaxVelocity()
        {
            Assert.AreEqual( Vector3.forward * MaxSpeed,

                playerMovementController.Move(
                    new Vector2(0,1f),
                    Vector3.forward,
                    Vector3.right,
                    Vector3.forward * MaxSpeed
                    )
                );
        }

        [Test]
        public void MoveVelocity_MovingNorthEast_ShouldUpdateXAndY()
        {
            Assert.AreEqual( (Vector3.right + Vector3.forward) * Acceleration,

                playerMovementController.Move(
                    new Vector2(1f,1f),
                    Vector3.forward,
                    Vector3.right,
                    Vector3.zero
                    )
                );
        }

        [Test]
        public void MoveVelocity_MovingNorthEastAtMaxSpeed_ShouldNotExceedMaxSpeed()
        {
                Vector3 movement = playerMovementController.Move(
                    new Vector2(1f,1f),
                    Vector3.forward,
                    Vector3.right,
                    MaxSpeed * (Vector3.right + Vector3.forward)
                    );
                Assert.IsTrue(Mathf.Approximately(Mathf.Pow(movement.x, 2), MaxSpeed/2));
                Assert.IsTrue(Mathf.Approximately(Mathf.Pow(movement.z, 2), MaxSpeed/2));
        }

        [Test]
        public void MoveVelocity_MovingSouthWest_ShouldUpdateXAndY()
        {
            Assert.AreEqual( (Vector3.right + Vector3.forward) * -Acceleration,

                playerMovementController.Move(
                    new Vector2(-1f,-1f),
                    Vector3.forward,
                    Vector3.right,
                    Vector3.zero
                    )
                );
        }

        [Test]
        public void MoveVelocity_MovingSouthWestAtMaxSpeed_ShouldNotExceedMaxSpeed()
        {


                Vector3 movement = playerMovementController.Move(
                    new Vector2(-1f,-1f),
                    Vector3.forward,
                    Vector3.right,
                    -MaxSpeed * (Vector3.right + Vector3.forward)
                    );

                Assert.IsTrue(Mathf.Approximately(Mathf.Pow(movement.x, 2), MaxSpeed/2));
                Assert.IsTrue(Mathf.Approximately(Mathf.Pow(movement.z, 2), MaxSpeed/2));
        }

        [Test]
        public void MoveVelocity_FacingWestAndMovingForward_ShouldMoveWest()
        {
            Assert.AreEqual( Vector3.right * Acceleration,

                playerMovementController.Move(
                    new Vector2(0,1f),
                    Vector3.right,
                    -Vector3.forward,
                    Vector3.zero
                    )
                );
        }
    }
}
