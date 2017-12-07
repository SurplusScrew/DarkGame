using UnityEngine;

public class InputController
{
	private ActionMap ActionMap;
	private IInputManager[] InputManagers { get; set; }

	public Vector2 LookVector
	{
		get; private set;
	}
	public Vector2 MoveVector
	{
		get; private set;
	}
	public InputController(ActionMap actionMap, IInputManager[] inputManagers)
	{
		this.ActionMap = actionMap;
		InputManagers = inputManagers;
	}

	public void RegisterButtonDelegate(Action action, ButtonInputDelegate buttonDelegate)
	{
		Action possibleAction;
		for(int i = 0; i < ActionMap.actions.Length; ++i)
		{
			possibleAction = ActionMap.actions[i].action;

			if(possibleAction == action )
			{
				ActionMap.actions[i].ButtonDelegate = buttonDelegate;
			}
		}
	}

	public void FixedTick()
	{
		UpdateLookAndMoveVectors();
	}

	public void UpdateLookAndMoveVectors()
	{
		LookVector = Vector2.zero;
		MoveVector = Vector2.zero;

		foreach( IInputManager inputManager in InputManagers )
		{
			if(LookVector == Vector2.zero)
			{
				LookVector = inputManager.GetLookVector();
			}

			if(MoveVector == Vector2.zero)
			{
				MoveVector = inputManager.GetMoveVector();
			}
		}
	}

    public void LateTick()
	{
		foreach( InputAction action in ActionMap.actions)
		{
			if(ActionIsRequired(action))
			{
				UseAction(action);
			}
		}
	}

	bool ActionIsRequired(InputAction action)
	{
		bool ActionIsRequired = false;
		foreach( IInputManager inputManager in InputManagers )
		{
			ActionIsRequired |= inputManager.ButtonIsPressed(action.action);
		}
		return ActionIsRequired;
	}

	void UseAction(InputAction action)
	{
		if(action.ButtonDelegate == null)
		{
			throw new System.Exception( "Tried to call an action that doesn't have a delegate attached.");
		}
		else
		{
			action.ButtonDelegate();
		}
	}
}