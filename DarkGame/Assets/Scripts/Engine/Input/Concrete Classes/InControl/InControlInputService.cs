using InControl;
using UnityEngine;

public class InControlInputService : IInputService
{
	Vector2 IInputService.GetLeftStick()
	{
		return InputManager.ActiveDevice.LeftStick.Vector;
	}
	Vector2 IInputService.GetRightStick()
	{
		return InputManager.ActiveDevice.RightStick.Vector;

	}
	public bool GetControlIsDown(InputControlType action)
	{
		return InputManager.ActiveDevice.GetControl(action).IsPressed;
	}

}