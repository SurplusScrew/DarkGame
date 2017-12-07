using InControl;
using UnityEngine;

public class KeyboardInputService : IInputService
{
	Vector2 IInputService.GetLeftStick()
	{
		return new Vector2(
			KeyboundInput.MoveHorizontal(),
			KeyboundInput.MoveVertical()
		);
	}
	Vector2 IInputService.GetRightStick()
	{
		return new Vector2(
			KeyboundInput.LookHorizontal(),
			KeyboundInput.LookVertical()
		);
	}
	public bool GetControlIsDown(InputControlType action)
	{
		return Input.GetKey(KeyboundInput.GetControl(action));
	}


}