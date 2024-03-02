using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.GameStateManagement.States;
using Scripts.BaseGameScripts.Helper;

namespace Scripts.GameScripts
{
    public class GameManager : SingletonMono<GameManager>
    {
        protected override void OnAwake()
        {
            BaseGameManager.Instance.GameStateManager.SetState(new StartState());
        }
    }
}