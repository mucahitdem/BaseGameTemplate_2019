using Scripts.BaseGameScripts.TimerManagement;
using Scripts.BaseGameScripts.UiManagement;
using UnityEngine;

namespace Scripts.GameScripts.GameStateManagement.GameStates
{
    public class GameStateLose : BaseGameState
    {
        public override void InitState()
        {
            TimerManager.Instance.RemoveAllTimers();
            Time.timeScale = 0f;
            UiActionManager.showUiItem?.Invoke(Defs.UI_KEY_LEVEL_FAILED_PANEL, null);
        }

        public override void ExitState()
        {
        }
    }
}