using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Utilities
{
    public class Test_UtilMaths
    {
        public class Vectors
        {
            Vector3 TestVector3;
            Vector2 TestVector2;


            [SetUp]
            public void setup()
            {
                TestVector3 = new Vector3(1f,2f,3f);
                TestVector2 = new Vector2(1f,2f);
            }
            [Test]
            public void V3toV2XZ_givenVector3_returnsCorrectVector2()
            {
                Assert.AreEqual(UtilMaths.V3toV2_XZ(TestVector3), new Vector2(1f,3f));
            }

            [Test]
            public void V3toV2XY_givenVector3_returnsCorrectVector2()
            {
                Assert.AreEqual(UtilMaths.V3toV2_XY(TestVector3), new Vector2(1f,2f));
            }

            [Test]
            public void V3toV2YZ_givenVector3_returnsCorrectVector2()
            {
                Assert.AreEqual(UtilMaths.V3toV2_YZ(TestVector3), new Vector2(2f,3f));
            }

            [Test]
            public void V2toV3XZ_givenVector3_returnsCorrectVector3()
            {
                Assert.AreEqual(UtilMaths.V2toV3_XZ(TestVector2), new Vector3(1f,0,2f));
            }

            [Test]
            public void V2toV3XY_givenVector3_returnsCorrectVector3()
            {
                Assert.AreEqual(UtilMaths.V2toV3_XY(TestVector2), new Vector3(1f,2,0f));
            }

            [Test]
            public void V2toV3YZ_givenVector2_returnsCorrectVector3()
            {
                Assert.AreEqual(UtilMaths.V2toV3_YZ(TestVector2), new Vector3(0,1f,2f));
            }

            [Test]
            public void Approximately_GivenTwoSimilarVectorsWithinAcceptableError_ReturnsTrue()
            {
                Assert.IsTrue(UtilMaths.Approximately(new Vector3(0,0,0), new Vector3(0.00001f,0.00001f,0.00001f), 0.01f));
            }

            [Test]
            public void Approximately_GivenTwoIdenticalVectors_ReturnsTrue()
            {
                Assert.IsTrue(UtilMaths.Approximately(new Vector3(1,1,1), new Vector3(1,1,1), 0.01f));
            }

            [Test]
            public void Approximately_GivenTwoDifferentVectorsOutsideAcceptableError_ReturnsFalse()
            {
                Assert.IsFalse(UtilMaths.Approximately(new Vector3(0,0,0), new Vector3(0.1f,0.1f,0.1f), 0.01f));
            }

            [Test]
            public void Approximately_GivenTwoVectorsWithOneAxisOutsideAcceptableError_ReturnsFalse()
            {
                Assert.IsFalse(UtilMaths.Approximately(new Vector3(0,0,0), new Vector3(0.1f,0f,0f), 0.01f));
            }

            [Test]
            public void Approximately_GivenTwoVectorsWithTwoAxesOutsideAcceptableError_ReturnsFalse()
            {
                Assert.IsFalse(UtilMaths.Approximately(new Vector3(0,0,0), new Vector3(0.1f,0.1f,0f), 0.01f));
            }
        }
    }
}
