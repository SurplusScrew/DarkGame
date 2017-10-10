public class KeyboardGameplayInputManager : GameplayInputManager
{
    public KeyboardGameplayInputManager(ref ActionMap actions)
    : base(ref actions)
	{
        InputService = new KeyboardInputService();
	}
}