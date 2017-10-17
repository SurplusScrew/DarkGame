using UnityEngine;
using InControl;
using System.Collections.Generic;

public class Keybinding
{
    public Dictionary<InControl.InputControlType, KeyCode> actions;

    public Keybinding()
    {
        actions = new Dictionary<InControl.InputControlType, KeyCode>();
        actions.Add(InputControlType.Action1, KeyCode.Space);
    }
    public KeyCode MoveUp
    {
        get{
            return KeyCode.W;
        }
    }
    public KeyCode MoveDown
    {
        get{
            return KeyCode.S;
        }
    }
    public KeyCode MoveLeft
    {
        get{
            return KeyCode.A;
        }
    }

    public KeyCode MoveRight
    {
        get{
            return KeyCode.D;
        }
    }
    public KeyCode LookUp
    {
        get{
            return KeyCode.UpArrow;
        }
    }
    public KeyCode LookDown
    {
        get{
            return KeyCode.DownArrow;
        }
    }
    public KeyCode LookLeft
    {
        get{
            return KeyCode.LeftArrow;
        }
    }
    public KeyCode LookRight
    {
        get{
            return KeyCode.RightArrow;
        }
    }
    public KeyCode GetControl(InputControlType action)
    {
        return actions[action];
    }
}