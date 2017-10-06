
using InControl;
using UnityEngine;


public abstract class MB_InputManager : MonoBehaviour, IInputManager
{
	public InputAction[] inputActions;
	protected IInputManager Manager;
   /* private void Awake()
	{
		Manager = new GameplayInputManager(ref inputActions);
    }*/
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


