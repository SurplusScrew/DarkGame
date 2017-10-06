public class MB_InControlInputManager : MB_InputManager
{
    private void Awake()
	{
		Manager = new InControlGameplayInputManager(ref inputActions);
	}
}