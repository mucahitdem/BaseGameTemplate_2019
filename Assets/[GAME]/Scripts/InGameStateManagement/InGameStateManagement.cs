namespace Scripts.InGameStateManagement
{
    public class InGameStateManagement
    {
        private IInGameState _currentState;

        public void SetState(IInGameState gameState)
        {
            _currentState?.OnExit();

            _currentState = gameState;
            _currentState.OnEnter();
        }
    }
}