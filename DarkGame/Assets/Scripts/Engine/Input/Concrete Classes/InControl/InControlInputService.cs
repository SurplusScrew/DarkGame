using InControl;
using UnityEngine;

public class InControlInputService : IInputService
{
	Vector2 IInputService.LeftStick
	{
		get{
			return InputManager.ActiveDevice.LeftStick.Vector;
		}
	}
	Vector2 IInputService.RightStick
	{
		get{
			return InputManager.ActiveDevice.RightStick.Vector;
		}
	}
	public bool GetControlIsDown(InputControlType action)
	{
		return InputManager.ActiveDevice.GetControl(action).IsPressed;
	}

}