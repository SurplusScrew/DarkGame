public class MB_InControlInputManager : MB_InputManager
{
    protected void Awake()
	{
        base.Awake();
		Manager = new InControlGameplayInputManager(ref actionMap);
	}
}