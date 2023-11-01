using Scripts.GameScripts._MainScene._GeneralUi;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement.CloseUis
{
    public class CloseWeaponRankUpPanel : CloseUi
    {
        protected override string UiItemIdToClose()
        {
            return Defs.UI_KEY_WEAPON_RANK_UP_PANEL;
        }
    }
}