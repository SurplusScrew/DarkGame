using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public enum InputAxis
{
    Horizontal,
    Vertical,
    All
}
public interface IInputManager
{
    Vector2 GetInputVector();
    bool GetButtonState(Action action);

}
