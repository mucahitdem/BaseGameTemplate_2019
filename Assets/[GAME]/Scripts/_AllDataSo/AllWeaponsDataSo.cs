using Scripts.GameScripts.WeaponManagement.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts._AllDataSo
{
    [CreateAssetMenu(fileName = "AllWeapons", menuName = "Game/Data/AllWeapons", order = 0)]
    public class AllWeaponsDataSo : ScriptableObject
    {
        [SerializeField]
        private BaseWeaponDataSo[] allWeapons;

        public BaseWeaponDataSo[] AllWeapons => allWeapons;

        public int GetWeaponIndex(BaseWeaponDataSo weaponDataSo)
        {
            for (var i = 0; i < allWeapons.Length; i++)
                if (weaponDataSo == allWeapons[i])
                    return i;

            return -1;
        }

        public void ResetData()
        {
            for (var i = 0; i < allWeapons.Length; i++)
            {
                var currentData = allWeapons[i].baseWeaponData;
                currentData.weaponLevelUpgradeData.upgradeCostValue.Reset();
                currentData.weaponLevelUpgradeData.attackDamageIncreaseValue.Reset();
                currentData.rankUpData.maxLevel.Reset();
                currentData.rankUpData.upgradeCostValue.Reset();
                currentData.rankUpData.attackDamageIncreaseValue.Reset();
            }
        }

        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllWeaponsDataSo s_instance;

        public static AllWeaponsDataSo Instance => s_instance ??= Resources.Load<AllWeaponsDataSo>("AllWeapons");

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("HoleData asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
    }
}