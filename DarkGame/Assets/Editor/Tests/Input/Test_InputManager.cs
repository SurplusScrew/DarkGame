
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class Test_InputManager
   {
       InControlInputManager manager;
        InputAction[] actions;
        IInputService InputService;

        [SetUp]
        public void setup()
        {
            InputService = Substitute.For<IInputService>();

            actions = new InputAction[]{

                new InputAction{
                    action = Action.Jump,
                    inputControlType = InControl.InputControlType.Action1
                }
            };

            manager = new InControlInputManager(ref actions);
            manager.inputService = InputService;

        }

        [TearDown]
        public void TearDown()
        {
            manager = null;
            actions = null;
            InputService = null;

        }

        [Test]
        public void ButtonIsPressed_InvalidAction_ShouldReturnFalse()
        {
            Assert.IsFalse(manager.ButtonIsPressed(Action.None));
        }

        [Test]
        public void ButtonIsPressed_ValidAction_ShouldReturnTrue()
        {
            InputService.GetControlIsDown(InControl.InputControlType.Action1).Returns(true);
            Assert.IsTrue(manager.ButtonIsPressed(Action.Jump));
        }

        [Test]
        public void MoveVectorIsNeeded_GetLeftStick_MoveVectorShouldMatchLeftStickVector()
        {
            Vector2 MoveVector = new Vector2(0,1f);
            InputService.LeftStick.Returns(MoveVector);
            Assert.Equals(manager.GetMoveVector(), MoveVector );
        }

        [Test]
        public void LookVectorIsNeeded_GetRightStick_LookVectorShouldMatchRightStickVector()
        {
            Vector2 LookVector = new Vector2(0,1f);
            InputService.RightStick.Returns(LookVector);
            Assert.Equals(manager.GetLookVector(), LookVector );
        }
    }
}
