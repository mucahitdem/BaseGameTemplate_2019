using Scripts.BaseGameScripts.GameStateManagement;
using Scripts.BaseGameScripts.UiManagement;

namespace Scripts.GameScripts.GameStateManagement.States
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