using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementController
{
     void Move(Vector2 moveDirection, Transform camera);

}
