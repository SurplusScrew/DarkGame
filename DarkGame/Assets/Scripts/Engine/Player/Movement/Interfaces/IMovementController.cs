using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementController
{
     Vector3 Move(Vector2 moveDirection, Transform camera, Vector3 velocity);
     Quaternion Rotate(Transform camera, float velocityMagnitude, bool threeDimensions = false);
}

public interface IMovementControllerImpl
{
     Vector3 Move(Vector2 moveVector, Vector3 lookVectorForward, Vector3 lookVectorRight, Vector3 initialVelocity);
    Quaternion UpdateModelRotation(Vector3 lookVector, Vector3 forward, float currentMovementSpeed);
}