using Scripts.GameScripts._MainScene._GeneralUi;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement
{
    public class RankUpSuccessfulPanel : CloseUi
    {
        protected override string GetUiId()
        {
            return Defs.UI_KEY_WEAPON_RANK_UP_SUCCESSFUL_PANEL;
        }

        protected override string UiItemIdToClose()
        {
            return Defs.UI_KEY_WEAPON_RANK_UP_SUCCESSFUL_PANEL;
        }
    }
}