
using System.Collections;
using NSubstitute;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace TestTools
{
	public class PlayerControllerTest
	{
		public class Movement : IPrebuildSetup
		{
			PlayerController player;
			IInputManager input;
			IMovementController movement;

			IRigidbodyPhysicsManager physics;
			public void Setup()
			{
				player = new GameObject("TEST_Player").AddComponent<PlayerController>();

				player.JumpStrength = 1f;

				input = Substitute.For<IInputManager>();

				movement = Substitute.For<IMovementController>();
				movement.GetAcceleration().Returns(1);

				player.inputManager = input;
				player.movementController = movement;
			}

			#region Lateral_Movement
			[UnityTest]
			[PrebuildSetup(typeof(PlayerControllerTest.Movement))]
			public IEnumerator Player_WhenLeftInputReceived_MoveLeft()
			{
				input.GetMoveVector().Returns(new Vector2(-1, 0));

				yield return null;

				Assert.AreEqual(player.transform.position.x, -1);
			}

			[UnityTest]
			[PrebuildSetup(typeof(PlayerControllerTest.Movement))]
			public IEnumerator Player_WhenRightInputReceived_MoveRight()
			{

				input.GetMoveVector().Returns(new Vector2(1, 0));

				yield return null;

				Assert.AreEqual(player.transform.position.x, 1);
			}

			[UnityTest]
			[PrebuildSetup(typeof(PlayerControllerTest.Movement))]
			public IEnumerator Player_WhenBackInputReceived_MoveBack()
			{
				input.GetMoveVector().Returns(new Vector2(0, -1));

				yield return null;

				Assert.AreEqual(player.transform.position.z, -1);
			}

			[UnityTest]
			[PrebuildSetup(typeof(PlayerControllerTest.Movement))]
			public IEnumerator Player_WhenForwardInputReceived_MoveForward()
			{
				input.GetMoveVector().Returns(new Vector2(0, 1));

				yield return null;

				Assert.AreEqual(player.transform.position.z, 1);
			}
			#endregion

			#region Jumping

			[UnityTest]
			[PrebuildSetup(typeof(PlayerControllerTest.Movement))]
			public IEnumerator Player_WhenJumpInputReceivedAndOnGround_Jumps()
			{
				physics.IsGrounded().Returns(true);

				movement.Jump(player.JumpStrength);

				yield return null;

				Assert.AreEqual(player.transform.position.y, player.JumpStrength);
			}

			[UnityTest]
			[PrebuildSetup(typeof(PlayerControllerTest.Movement))]
			public IEnumerator Player_WhenJumpInputReceivedAndNotOnGround_DoesNotJump()
			{
				Vector3 playerPosition = player.transform.position;

				physics.IsGrounded().Returns(true);

				movement.Jump(player.JumpStrength);

				yield return null;

				Assert.AreEqual(player.transform.position, playerPosition);
			}

			[UnityTest]
			[PrebuildSetup(typeof(PlayerControllerTest.Movement))]
			public IEnumerator PlayerIsOnSurface_WhenJumpInputReceived_PlayerIsOnSurfaceReturnsFalse()
			{
				Assert.IsTrue(physics.IsGrounded());

				movement.Jump(player.JumpStrength);

				yield return null;

				Assert.IsFalse(physics.IsGrounded());
			}

			#endregion
		}
	}
}
