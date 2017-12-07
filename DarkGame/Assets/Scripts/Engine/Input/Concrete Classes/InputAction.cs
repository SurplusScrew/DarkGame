using System;
using InControl;
using UnityEngine;

public delegate void ButtonInputDelegate();

[Serializable]
public struct InputAction {
	public Action action;
	public InputControlType inputControlType;
	public ButtonInputDelegate ButtonDelegate;
}