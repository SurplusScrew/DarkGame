
using UnityEngine;


public class MB_InControlInputManager : MonoBehaviour, IInputManager
{
	public InputAction[] inputActions;
	private IInputManager Manager;

	private void Awake()
	{
		Manager = new InControlInputManager(ref inputActions);
	}
	public bool ButtonIsPressed(Action action)
    {
		return Manager.ButtonIsPressed(action);
	}
	public Vector2 GetMoveVector()
	{
		return Manager.GetMoveVector();
	}
	public Vector2 GetLookVector()
	{
		return Manager.GetLookVector();
	}
}

public class InControlInputManager : IInputManager
{
	public InputAction[] inputActions;
	public IInputService inputService;

	public InControlInputManager(ref InputAction[] actions)
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


