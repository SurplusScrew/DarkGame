using System;
using System.Collections;
using System.Collections.Generic;
using InControl;
using SerializableCollections;
using UnityEngine;

[Serializable]
public struct InputAction {
	public Action action;
	public InputControlType inputControlType;

}
public class InControlInputManager : MonoBehaviour, IInputManager
{

	public InputAction[] inputActions;


	public void Awake()
	{
		if(inputActions == null)
		{
			inputActions = new InputAction[0];
		}
	}
    public bool ButtonIsPressed(Action action)
    {
		foreach(InputAction iAction in inputActions)
		{
			if(iAction.action == action)
			{
				return InputManager.ActiveDevice.GetControl(iAction.inputControlType).IsPressed;
			}
		}
		return false;
    }

    public float GetInputForAxis(InputAxis axis)
    {
			return
			axis == InputAxis.Horizontal ?
			InputManager.ActiveDevice.LeftStickX.Value :
			InputManager.ActiveDevice.LeftStickY.Value ;
    }
	public Vector2 GetMoveVector()
	{
		return InputManager.ActiveDevice.LeftStick.Vector;
	}
	public Vector2 GetLookVector()
	{
		return InputManager.ActiveDevice.RightStick.Vector;
	}

}
