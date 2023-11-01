namespace Scripts.InGameStateManagement
{
    public interface IInGameState
    {
        void OnEnter();
        void OnExit();
    }
}