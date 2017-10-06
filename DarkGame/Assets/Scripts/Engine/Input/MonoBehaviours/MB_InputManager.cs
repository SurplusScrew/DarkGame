
using InControl;
using UnityEngine;

[RequireComponent(typeof(MB_ActionMapWrapper))]
public abstract class MB_InputManager : MonoBehaviour, IInputManager
{
	protected ActionMap actionMap;
	protected IInputManager Manager;

    protected void Awake()
	{
		actionMap = GetComponent<MB_ActionMapWrapper>().actionMap;
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


