using UnityEngine;

public abstract class GameplayInputManager : IInputManager
{
	public InputAction[] inputActions;
	public IInputService inputService;

	public GameplayInputManager(ref InputAction[] actions)
	{
		inputActions = actions;
		inputService = new InControlInputService();
	}
    public bool ButtonIsPressed(Action action)
    {
		foreach(InputAction iAction in inputActions)
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