using Scripts.BaseGameScripts.UiManagement;
using Scripts.GameScripts;

namespace Scripts.BaseGameScripts.GameStateManagement.States
{
    public class GamePlayState : IGameState
    {
        public void OnEnter()
        {
            UiActionManager.showUiItem?.Invoke(Defs.UI_KEY_GAME_PLAY_SCREEN, null);
        }

        public void OnExit()
        {
            UiActionManager.hideUiItem?.Invoke(Defs.UI_KEY_GAME_PLAY_SCREEN, null);
        }
    }
}