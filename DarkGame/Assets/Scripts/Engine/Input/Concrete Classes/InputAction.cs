using System;
using InControl;

[Serializable]
public struct InputAction {
	public Action action;
	public InputControlType inputControlType;

}