
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Input
{
    public class Test_InputController
    {
        InputController controller;
        IInputManager[] managers;
        ActionMap actions;

         [SetUp]
        public void setup()
        {
            InitialiseActionMap();
            InitialiseInputManagers();

            controller = new InputController(actions, managers);
        }

        [TearDown]
        public void TearDown()
        {
            actions = null;
            managers = null;
        }

        public void InitialiseActionMap()
        {
            actions = new ActionMap();
            actions.actions = new InputAction[]{

                new InputAction{
                    action = Action.Jump,
                    inputControlType = InControl.InputControlType.Action1,
                },
                new InputAction{
                    action = Action.None,
                    inputControlType = InControl.InputControlType.Action2,
                }
            };
        }

        public void InitialiseInputManagers()
            {
                managers = new IInputManager[3] {
                     Substitute.For<IInputManager>(),
                     Substitute.For<IInputManager>(),
                     Substitute.For<IInputManager>()
                };
            }

        [Test]
        public void InputControllerCreated_LookVector_DefaultsToZero()
        {
            Assert.True(controller.LookVector == Vector2.zero);
        }
        [Test]
        public void InputControllerCreated_MoveVector_DefaultsToZero()
        {
            Assert.True(controller.MoveVector == Vector2.zero);
        }

        protected class TestDelegateClass
            {
                public bool DelegateMethodHasBeenTriggered = false;
                public TestDelegateClass() {}
                public void DelegateMethod()
                {
                    DelegateMethodHasBeenTriggered = true;
                }
            }
        [Test]
        public void InputControllerCreated_DelegateRegistered_DelegateExistsInRegisterAndIsCalled()
        {
            TestDelegateClass TD_Class = new TestDelegateClass();

            controller.RegisterButtonDelegate( Action.Jump, TD_Class.DelegateMethod );

            managers[0].ButtonIsPressed(Action.Jump).Returns(true);

            Assert.False(TD_Class.DelegateMethodHasBeenTriggered);

            controller.LateTick();

            Assert.True(TD_Class.DelegateMethodHasBeenTriggered);
        }

        [Test]
        public void InputControllerButtonDelegate_DelegateActionNotRegistered_ExceptionIsThrown()
        {
            bool ExceptionWasThrown = false;
            try
            {
                managers[0].ButtonIsPressed(Action.Jump).Returns(true);

                controller.LateTick();
            }
            catch(System.Exception e)
            {
                ExceptionWasThrown = true;
            }
            Assert.True(ExceptionWasThrown);
        }

        [Test]
        public void InputControllerCreated_DelegateRegistered_DelegateIsNotCalledDoesNotExecute()
        {
            TestDelegateClass TD_Class = new TestDelegateClass();

            controller.RegisterButtonDelegate( Action.Climb, TD_Class.DelegateMethod );
            managers[0].ButtonIsPressed(Action.Jump).Returns(true);

            Assert.False(TD_Class.DelegateMethodHasBeenTriggered);

            try
            {
                controller.LateTick();
            }
            catch(System.Exception e) {}

            finally
            {
                Assert.False(TD_Class.DelegateMethodHasBeenTriggered);
            }
        }
    }
}
