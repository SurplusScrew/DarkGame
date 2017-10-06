using UnityEngine;

public abstract class GameplayInputManager : IInputManager
{
	public ActionMap inputActions;
	public IInputService inputService;

	public GameplayInputManager(ref ActionMap actions)
	{
		inputActions = actions;
	}
    public bool ButtonIsPressed(Action action)
    {
		foreach(InputAction iAction in inputActions.actions)
		{
			if(iAction.action == action)
			{
				return inputService.GetControlIsDown(iAction.inputControlType);
			}
		}
		return false;
    }

	public Vector2 GetMoveVector()
	{
		return inputService.LeftStick;
	}
	public Vector2 GetLookVector()
	{
		return inputService.RightStick;
	}
}