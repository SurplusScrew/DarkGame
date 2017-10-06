public class KeyboardGameplayInputManager : GameplayInputManager
{
    public KeyboardGameplayInputManager(ref InputAction[] actions)
    : base(ref actions)
	{
        inputService = new KeyboardInputService();
	}
}