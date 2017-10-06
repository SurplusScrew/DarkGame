public class InControlGameplayInputManager : GameplayInputManager
{
    public InControlGameplayInputManager(ref ActionMap actions)
    : base(ref actions)
	{
        InputService = new InControlInputService();
	}
}