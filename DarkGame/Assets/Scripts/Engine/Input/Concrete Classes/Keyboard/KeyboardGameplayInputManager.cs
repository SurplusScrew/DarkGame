public class KeyboardGameplayInputManager : GameplayInputManager
{
    public KeyboardGameplayInputManager(ref ActionMap actions)
    : base(ref actions)
	{
        inputService = new KeyboardInputService();
	}
}