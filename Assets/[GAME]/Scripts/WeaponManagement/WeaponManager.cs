using Scripts._MainScene.WeaponUiManagement;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.UiManagement;
using Scripts.GameScripts._AllDataSo;
using Scripts.GameScripts._MainScene.WeaponUiManagement;
using Scripts.GameScripts.WeaponManagement.Weapons;
using UnityEngine;

namespace Scripts.GameScripts.WeaponManagement
{
    public class WeaponManager : BaseComponent
    {
        private BaseWeaponDataSo _equippedWeapon;
        private WeaponUiManager _weaponUiManager;

        [SerializeField]
        private WeaponActivator weaponActivator;

        public BaseWeaponDataSo EquippedWeaponDataSo
        {
            get
            {
                if (_equippedWeapon == null)
                {
                    var weaponIndex = PlayerPrefs.GetInt(Defs.SAVE_KEY_EQUIPPED_WEAPON, 0);
                    _equippedWeapon = AllWeaponsDataSo.Instance.AllWeapons[weaponIndex];
                }

                return _equippedWeapon;
            }
        }

        private WeaponUiManager WeaponUiManager
        {
            get
            {
                if (!_weaponUiManager)
                    _weaponUiManager = (WeaponUiManager) UiActionManager.getUiItem?.Invoke(Defs.UI_KEY_WEAPON_MANAGER);
                return _weaponUiManager;
            }
        }

        private void Awake()
        {
            if (weaponActivator)
                weaponActivator.Insert(this);
            if (WeaponUiManager)
                WeaponUiManager.Insert(this);
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            WeaponUiActionManager.onWeaponEquipped += OnWeaponEquipped;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            WeaponUiActionManager.onWeaponEquipped -= OnWeaponEquipped;
        }

        private void OnWeaponEquipped(BaseWeaponDataSo weaponDataSo)
        {
            PlayerPrefs.SetInt(Defs.SAVE_KEY_EQUIPPED_WEAPON, AllWeaponsDataSo.Instance.GetWeaponIndex(weaponDataSo));
            _equippedWeapon = weaponDataSo;
            weaponActivator.ActivateEquippedWeapon();
        }
    }
}