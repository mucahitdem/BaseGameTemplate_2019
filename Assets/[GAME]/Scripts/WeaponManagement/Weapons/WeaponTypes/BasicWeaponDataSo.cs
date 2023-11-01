using Scripts.GameScripts._AllDataSo;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.WeaponManagement.Weapons.WeaponTypes
{
    [CreateAssetMenu(fileName = "Basic Weapon Data", menuName = "Game/Weapon/Basic Weapon Data", order = 0)]
    [InlineEditor]
    public class BasicWeaponDataSo : BaseWeaponDataSo
    {
        public BasicWeaponData basicWeaponData;

        [Button]
        private void SelectWeapon()
        {
            PlayerPrefs.SetInt(Defs.SAVE_KEY_EQUIPPED_WEAPON, AllWeaponsDataSo.Instance.GetWeaponIndex(this));
        }
    }
}