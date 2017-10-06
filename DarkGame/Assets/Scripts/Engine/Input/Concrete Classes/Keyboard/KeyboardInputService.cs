using InControl;
using UnityEngine;

public class KeyboardInputService : IInputService
{
	Vector2 IInputService.LeftStick
	{
		get{
			return new Vector2(
				KeyboundInput.MoveHorizontal(),
				KeyboundInput.MoveVertical()
			);
		}
	}
	Vector2 IInputService.RightStick
	{
		get{
			return new Vector2(
				KeyboundInput.LookHorizontal(),
				KeyboundInput.LookVertical()
			);
		}
	}
	public bool GetControlIsDown(InputControlType action)
	{
		return Input.GetKey(KeyboundInput.GetControl(action));
	}


}