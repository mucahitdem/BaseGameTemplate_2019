using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.WeaponManagement.Weapons;
using Scripts.WeaponManagement.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.WeaponManagement
{
    public class WeaponActivator : BaseComponent
    {
        private BaseWeapon _equippedWeapon;

        private BaseWeaponDataSo _equippedWeaponDataSo;
        private WeaponManager _weaponManager;

        [SerializeField]
        [ReadOnly]
        private BaseWeapon[] allWeapons;

        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            _weaponManager = (WeaponManager) baseComponent;
            ActivateEquippedWeapon();
        }

        public void ActivateEquippedWeapon()
        {
            allWeapons = GetComponentsInChildren<BaseWeapon>(true);
            _equippedWeaponDataSo = _weaponManager.EquippedWeaponDataSo;
            EnableWeapon();
        }

        private void EnableWeapon()
        {
            for (var i = 0; i < allWeapons.Length; i++)
            {
                var currentWeapon = allWeapons[i];

                if (currentWeapon.WeaponDataSo == _equippedWeaponDataSo)
                {
                    _equippedWeapon = currentWeapon;
                    _equippedWeapon.Go.SetActive(true);
                }
                else
                {
                    currentWeapon.Go.SetActive(false);
                }
            }
        }
    }
}