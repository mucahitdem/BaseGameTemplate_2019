using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;

namespace Scripts.GameScripts.LevelEndManagement
{
    public class LevelFailedPanel : BaseUiItem
    {
        protected override string GetUiId()
        {
            return Defs.UI_KEY_LEVEL_FAILED_PANEL;
        }
    }
}