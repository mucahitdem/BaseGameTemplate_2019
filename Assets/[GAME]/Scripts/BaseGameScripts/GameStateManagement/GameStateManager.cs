using Scripts.BaseGameScripts.ComponentManagement;

namespace Scripts.BaseGameScripts.GameStateManagement
{
    public class GameStateManager : BaseComponent
    {
        private IGameState _currentState;

        public void SetState(IGameState gameState)
        {
            _currentState?.OnExit();

            _currentState = gameState;
            _currentState.OnEnter();
        }
    }
}