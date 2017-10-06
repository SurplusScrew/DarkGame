using InControl;
using UnityEngine;

public class KeyboundInput
{
    public static Keybinding keybinding = new Keybinding();

    public static int MoveVertical()
    {
        int up = Input.GetKey(keybinding.MoveUp) ? 1 : 0;
        int down = Input.GetKey(keybinding.MoveDown) ? 1 : 0;
        return up - down;

    }
    public static int MoveHorizontal()
    {
        int left = Input.GetKey(keybinding.MoveLeft) ? 1 : 0;
        int right = Input.GetKey(keybinding.MoveRight) ? 1 : 0;
        return right - left;
    }

	public static int LookVertical()
    {
        int up = Input.GetKey(keybinding.LookUp) ? 1 : 0;
        int down = Input.GetKey(keybinding.LookDown) ? 1 : 0;
        return up - down;
    }
	public static int LookHorizontal()
    {
        int left = Input.GetKey(keybinding.LookLeft) ? 1 : 0;
        int right = Input.GetKey(keybinding.LookRight) ? 1 : 0;
        return right - left;
    }

	public static KeyCode GetControl(InputControlType action)
    {
        return keybinding.GetControl(action);
    }
}