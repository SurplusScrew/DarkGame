public class MB_InControlInputManager : MB_InputManager
{
    protected new void Awake()
	{
        base.Awake();
		Manager = new InControlGameplayInputManager(ref actionMap);
	}
}