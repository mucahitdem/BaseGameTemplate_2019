using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;

namespace Scripts.GameScripts.LevelEndManagement
{
    public class LevelSuccessPanel : BaseUiItem
    {
        protected override string GetUiId()
        {
            return Defs.UI_KEY_LEVEL_SUCCESS_PANEL;
        }
    }
}