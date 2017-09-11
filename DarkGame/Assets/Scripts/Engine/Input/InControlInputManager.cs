using System;
using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class InControlInputManager : MonoBehaviour, IInputManager
{
	[SerializeField]
	public Dictionary<Action, InputControl> inputActions;

	public void Awake()
	{

	}
    public bool GetButtonState(Action action)
    {
        return inputActions[action].IsPressed;
    }

    public float GetInputForAxis(InputAxis axis)
    {
			return
			axis == InputAxis.Horizontal ?
			InputManager.ActiveDevice.LeftStickX :
			InputManager.ActiveDevice.LeftStickY ;
    }
	public Vector2 GetInputVector()
	{
		return InputManager.ActiveDevice.LeftStick;
	}


}
