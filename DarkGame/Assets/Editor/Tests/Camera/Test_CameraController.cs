using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class Test_CameraController
   {
        PlayerCameraController CameraController;
        Quaternion startingRotation;

        float RotationSpeed = 1f;
        float XLimit = 50;

        [SetUp]
        public void setup()
        {
            //Q(0,0,0,1) or E(0,0,0)
            startingRotation = Quaternion.identity;
            CameraController = new PlayerCameraController(ref RotationSpeed, ref XLimit);
        }

        [TearDown]
        public void TearDown()
        {
            CameraController = null;

        }


        [Test]
        public void Camera_ReceivesRotationInput_IsRotatedHorizontally()
        {
            Quaternion RotationOutcome = CameraController.Rotate(startingRotation, new Vector2(180f, 0));
            Assert.AreEqual(RotationOutcome.eulerAngles, new Quaternion(0,1f,0,0).eulerAngles);
        }

        [Test]
        public void Camera_ReceivesRotationInput_IsRotatedVertically()
        {
            Quaternion RotationOutcome = CameraController.Rotate(startingRotation, new Vector2(0, 180f));

            Assert.AreEqual(RotationOutcome, Quaternion.Euler(new Vector3(XLimit, 0, 0)));
        }
#region LimitAngle
        [Test]
        public void CameraIsMovedUp_AngleExceedsLimitPositively_AngleIsLimited()
        {
            Vector3 PositivelyLimitedAngle = new Vector3(XLimit, 0, 0);
            Assert.AreEqual(PositivelyLimitedAngle, CameraController.LimitAngle( new Vector3(XLimit + 10f, 0, 0)));
        }

        [Test]
        public void CameraIsMovedDown_AngleExceedsLimitNegatively_AngleIsLimited()
        {
            Vector3 NegativelyLimitedAngle = new Vector3(360f - XLimit, 0, 0);
            Assert.AreEqual(NegativelyLimitedAngle, CameraController.LimitAngle( new Vector3(360f-XLimit - 10f, 0, 0)));
        }

        [Test]
        public void CameraIsMovedUp_AngleDoesNotExceedPositiveLimit_AngleIsUnchanged()
        {
            Vector3 PositivelyMovedAngle = new Vector3(XLimit/2, 0, 0);
            Assert.AreEqual(PositivelyMovedAngle, CameraController.LimitAngle( PositivelyMovedAngle ));
        }

        [Test]
        public void CameraIsMovedDown_AngleDoesNotExceedNegativeLimit_AngleIsUnchanged()
        {
            Vector3 NegativelyMovedAngle = new Vector3(-XLimit/2, 0, 0);
            Assert.AreEqual(NegativelyMovedAngle, CameraController.LimitAngle( NegativelyMovedAngle ));
        }
    #endregion
   }
}