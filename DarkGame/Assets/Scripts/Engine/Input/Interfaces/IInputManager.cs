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
    Vector2 GetMoveVector();
    Vector2 GetLookVector();
    bool ButtonIsPressed(Action action);

}


public interface IInputManagerImpl
{
    Vector2 GetMoveVector();
    Vector2 GetLookVector();
    bool ButtonIsPressed(Action action);

}


