using Scripts.BaseGameScripts.UiManagement;
using Scripts.GameScripts;
using Scripts.GameScripts.GameStateManagement;

namespace Scripts.BaseGameScripts.GameStateManagement.States
{
    public class WinState : IGameState
    {
        public void OnEnter()
        {
            UiActionManager.showUiItem?.Invoke(Defs.UI_KEY_WIN_SCREEN, null);
        }

        public void OnExit()
        {
            UiActionManager.hideUiItem?.Invoke(Defs.UI_KEY_WIN_SCREEN, null);
        }
    }
}