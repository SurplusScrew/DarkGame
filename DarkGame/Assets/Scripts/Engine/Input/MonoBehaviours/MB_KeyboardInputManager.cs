public class MB_KeyboardInputManager : MB_InputManager
{
    private void Awake()
	{
		Manager = new KeyboardGameplayInputManager(ref inputActions);
	}
}