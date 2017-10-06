using UnityEngine;
using InControl;

public class Keybinding
{
    public InputAction[] actions;
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
        return KeyCode.None;
    }
}