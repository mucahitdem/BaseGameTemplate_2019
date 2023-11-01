using Scripts.GameScripts._MainScene._GeneralUi;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement.CloseUis
{
    public class CloseWeaponSpecsUi : CloseUi
    {
        protected override string UiItemIdToClose()
        {
            return Defs.UI_KEY_WEAPON_SPECS;
        }
    }
}