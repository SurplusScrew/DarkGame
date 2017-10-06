public class InControlGameplayInputManager : GameplayInputManager
{
    public InControlGameplayInputManager(ref InputAction[] actions)
    : base(ref actions)
	{
        inputService = new InControlInputService();
	}
}