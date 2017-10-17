public class MB_KeyboardInputManager : MB_InputManager
{
    protected new void Awake()
	{
        base.Awake();
		Manager = new KeyboardGameplayInputManager(ref actionMap );
	}
}