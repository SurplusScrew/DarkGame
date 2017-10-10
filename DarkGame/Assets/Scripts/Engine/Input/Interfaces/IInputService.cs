using UnityEngine;
using InControl;

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