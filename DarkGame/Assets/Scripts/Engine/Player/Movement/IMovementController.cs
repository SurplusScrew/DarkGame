using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementController
{
    void Jump(float jumpStrength);
    void Move(Vector3 moveVector);
    float GetAcceleration();
}
