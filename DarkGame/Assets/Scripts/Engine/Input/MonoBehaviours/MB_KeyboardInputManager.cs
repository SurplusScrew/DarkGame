public class MB_KeyboardInputManager : MB_InputManager
{
    protected void Awake()
	{
        base.Awake();
		Manager = new KeyboardGameplayInputManager(ref actionMap );
	}
}