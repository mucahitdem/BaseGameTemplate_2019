using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.UI;
using Scripts.State._Interface;
using Scripts.State.GameStates;

namespace Scripts.BaseGameSystemRelatedScripts.UI
{
    public class StartButton : UiButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            GlobalReferences.Instance.gameStateManager.NextState(((IGameState)typeof(GameState03_1Win)));
        }
    }
}