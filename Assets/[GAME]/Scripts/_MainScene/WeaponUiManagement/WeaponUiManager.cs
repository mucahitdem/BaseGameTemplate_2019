using Scripts.BaseGameScripts.UiManagement;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.GameScripts;
using Scripts.GameScripts._MainScene.WeaponUiManagement;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.WeaponManagement;
using Scripts.GameScripts.WeaponManagement.Weapons;
using UnityEngine;

namespace Scripts._MainScene.WeaponUiManagement
{
    public class WeaponUiManager : BaseUiItem
    {
        private WeaponManager _weaponManager;

        [SerializeField]
        private WeaponStatsManagerUi[] weaponStatsUi;

        private WeaponManager WeaponManager
        {
            get
            {
                if (!_weaponManager)
                    _weaponManager = GameManager.Instance.WeaponManager;
                return _weaponManager;
            }
        }

        protected override string GetUiId()
        {
            uiItemId = Defs.UI_KEY_WEAPON_MANAGER;
            return uiItemId;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            WeaponUiActionManager.onClickedWeaponStatUi += OnClickedWeaponStatUi;
            WeaponUiActionManager.onWeaponLevelUpgraded += OnWeaponLevelUpgraded;
            WeaponUiActionManager.onWeaponRankUpgraded += OnWeaponRankUpgraded;
            WeaponUiActionManager.onClickedOpenRankUpButton += OnClickedRankUpButton;
            WeaponUiActionManager.onWeaponEquipped += OnNewWeaponEquipped;
            WeaponUiActionManager.getEquippedWeapon += GetEquippedWeapon;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            WeaponUiActionManager.onClickedWeaponStatUi -= OnClickedWeaponStatUi;
            WeaponUiActionManager.onWeaponLevelUpgraded -= OnWeaponLevelUpgraded;
            WeaponUiActionManager.onWeaponRankUpgraded -= OnWeaponRankUpgraded;
            WeaponUiActionManager.onClickedOpenRankUpButton -= OnClickedRankUpButton;
            WeaponUiActionManager.onWeaponEquipped -= OnNewWeaponEquipped;
            WeaponUiActionManager.getEquippedWeapon -= GetEquippedWeapon;
        }


        private void OnWeaponRankUpgraded(BaseWeaponDataSo obj)
        {
            WeaponUiActionManager.updateAllUi?.Invoke();
        }

        private BaseWeaponDataSo GetEquippedWeapon()
        {
            return WeaponManager.EquippedWeaponDataSo;
        }


        private void OnClickedRankUpButton(BaseWeaponDataSo weaponDataSo)
        {
            UiActionManager.showUiItem?.Invoke(Defs.UI_KEY_WEAPON_RANK_UP_PANEL, weaponDataSo);
        }

        private void OnWeaponLevelUpgraded(BaseWeaponDataSo weaponDataSo)
        {
            WeaponUiActionManager.updateAllUi?.Invoke();
        }

        private void OnClickedWeaponStatUi(BaseWeaponDataSo weaponDataSo)
        {
            UiActionManager.showUiItem?.Invoke(Defs.UI_KEY_WEAPON_SPECS, weaponDataSo);
        }

        private void OnNewWeaponEquipped(BaseWeaponDataSo weaponEquipped)
        {
            for (var i = 0; i < weaponStatsUi.Length; i++)
            {
                var currentUi = weaponStatsUi[i];
                currentUi.OnEquippedWeaponUpdated(weaponEquipped);
            }
        }
    }
}