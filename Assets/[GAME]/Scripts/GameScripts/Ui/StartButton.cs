using Scripts.BaseGameScripts;
using Scripts.UI;

namespace Scripts.GameScripts.Ui
{
    public class StartButton : UiButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            GlobalReferences.Instance.gameStateManager.NextState();
        }
    }
}