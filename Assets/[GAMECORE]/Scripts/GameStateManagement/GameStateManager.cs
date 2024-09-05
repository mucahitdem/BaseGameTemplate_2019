using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.GameStateManagement;

namespace Scripts.GameStateManagement
{
    public class GameStateManager : BaseComponent
    {
        private IGameState _currentState;

        public void SetState(IGameState gameState)
        {
            _currentState?.OnExit();

            //DebugHelper.LogGreen("GAME STATE : " + gameState.ToString());
            _currentState = gameState;
            _currentState.OnEnter();
        }
    }
}