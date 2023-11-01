using System;
using Scripts.GameScripts.WeaponManagement.Weapons;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement
{
    public static class WeaponUiActionManager
    {
        public static Action<BaseWeaponDataSo> onClickedWeaponStatUi;
        public static Action<BaseWeaponDataSo> onClickedOpenRankUpButton;

        public static Action<BaseWeaponDataSo> onWeaponEquipped;

        public static Action<BaseWeaponDataSo> onWeaponLevelUpgraded;
        public static Action<BaseWeaponDataSo> onWeaponRankUpgraded;

        public static Func<BaseWeaponDataSo> getEquippedWeapon;

        public static Action updateAllUi;
    }
}