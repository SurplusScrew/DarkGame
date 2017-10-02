using System;
using InControl;
using UnityEngine;

public interface IInputService
{
	Vector2 LeftStick
	{
		get;
	}
	Vector2 RightStick
	{
		get;
	}

	bool GetControlIsDown(InputControlType action);
}

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