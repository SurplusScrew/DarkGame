using UnityEngine;
using InControl;

public interface IInputService
{
	Vector2 GetLeftStick();

	Vector2 GetRightStick();


	bool GetControlIsDown(InputControlType action);
}