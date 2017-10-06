using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementController
{
    GameObject Player { get; set; }

    void Jump(float jumpStrength);
    void Move(Vector2 moveVector, Vector3 forwardVector);
    float GetAcceleration();
}
