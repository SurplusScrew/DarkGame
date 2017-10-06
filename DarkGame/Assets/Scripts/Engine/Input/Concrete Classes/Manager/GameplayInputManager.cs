using UnityEngine;

public abstract class GameplayInputManager : IInputManager
{
	public ActionMap InputActions;
	public IInputService InputService{
		get;
		set;
	}

	public GameplayInputManager(ref ActionMap actions)
	{
		InputActions = actions;
	}
    public bool ButtonIsPressed(Action action)
    {
		foreach(InputAction iAction in InputActions.actions)
		{
			if(iAction.action == action)
			{
				return InputService.GetControlIsDown(iAction.inputControlType);
			}
		}
		return false;
    }

	public Vector2 GetMoveVector()
	{
		return InputService.LeftStick;
	}
	public Vector2 GetLookVector()
	{
		return InputService.RightStick;
	}
}