using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraController
{
    GameObject Camera { get; set; }
    void ChaseTarget(GameObject target);
    void Rotate(Vector2 moveVector);
    Vector3 GetForwardVector();
}
