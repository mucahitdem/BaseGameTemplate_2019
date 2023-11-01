using System;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoadManagement;
using Scripts.BaseGameScripts.SourceManagement;
using Scripts.GameScripts.WeaponManagement.WeaponLevelAndRankManagement;
using Scripts.GameScripts.WeaponManagement.WeaponLevelAndRankManagement.RankManagement;
using Scripts.WeaponManagement.WeaponLevelAndRankManagement;
using Scripts.WeaponManagement.WeaponLevelAndRankManagement.RankManagement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.WeaponManagement.Weapons
{
    [Serializable]
    public class BaseWeaponData : ISaveAndLoad
    {
        public float bulletDamage;
        public float fireRange;
        public float fireRate;
        public int maxAmmo;
        public float maxAngle;
        public int projectiles;

        public WeaponRankData rankUpData;
        public float reloadDuration;

        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite weaponIcon;

        [FormerlySerializedAs("weaponUpgradeData")]
        public WeaponLevelUpgradeData weaponLevelUpgradeData;

        public string weaponName;

        [SerializeField]
        private GameObject weaponPrefab;

        public int weaponStartLevel;

        public void Save()
        {
            rankUpData.maxLevel.Save();
            rankUpData.upgradeCostValue.Save();
            rankUpData.attackDamageIncreaseValue.Save();
            weaponLevelUpgradeData.upgradeCostValue.Save();
            weaponLevelUpgradeData.attackDamageIncreaseValue.Save();
        }

        public void Load()
        {
            rankUpData.maxLevel.Load();
            rankUpData.upgradeCostValue.Load();
            rankUpData.attackDamageIncreaseValue.Load();
            weaponLevelUpgradeData.upgradeCostValue.Load();
            weaponLevelUpgradeData.attackDamageIncreaseValue.Load();
        }

        public float GetCurrentAttackDamage()
        {
            var value = GetCurrentRankUpAttackDamage() + GetCurrentLevelAttackDamage();
            return value;
        }

        public float GetNextAttackDamageOnRankUp()
        {
            var value = GetNextLevelRankUpAttackDamage() + GetCurrentLevelAttackDamage();
            return value;
        }

        public BaseSourceDataSo GetLevelUpgradeSourceType()
        {
            return weaponLevelUpgradeData.sourceType;
        }


        public BaseSourceDataSo GetRankUpgradeSourceType()
        {
            return rankUpData.sourceType;
        }


        #region Rank Up Methods

        public int GetCurrentWeaponRank()
        {
            return rankUpData.attackDamageIncreaseValue.CurrentLevel;
        }

        public int GetCurrentRankUpMaxLevel()
        {
            return (int) rankUpData.maxLevel.CurrentValue;
        }

        public int GetNextRankUpMaxLevel()
        {
            return (int) rankUpData.maxLevel.GetNextLevelValues();
        }

        public int GetNextRankUpPrice()
        {
            return (int) rankUpData.upgradeCostValue.CurrentValue;
        }

        private float GetCurrentRankUpAttackDamage()
        {
            return rankUpData.attackDamageIncreaseValue.CurrentValue;
        }

        private float GetNextLevelRankUpAttackDamage()
        {
            return rankUpData.attackDamageIncreaseValue.GetNextLevelValues();
        }

        public void UpgradeWeaponRank()
        {
            if (rankUpData.attackDamageIncreaseValue.UpgradeMaxed)
                DebugHelper.LogYellow("LEVEL MAXED");

            rankUpData.upgradeCostValue.Upgrade();
            rankUpData.attackDamageIncreaseValue.Upgrade();
            rankUpData.maxLevel.Upgrade();
        }

        #endregion

        #region Weapon Level Methods

        public int GetCurrentWeaponLevel()
        {
            var level = weaponLevelUpgradeData.attackDamageIncreaseValue.CurrentLevel;
            return level;
        }

        public int GetLevelUpgradePrice()
        {
            var price = (int) weaponLevelUpgradeData.upgradeCostValue.CurrentValue;
            DebugHelper.LogRed(weaponName + " LEVEL : " + weaponLevelUpgradeData.upgradeCostValue.CurrentLevel);
            DebugHelper.LogRed(weaponName + " PRICE : " + weaponLevelUpgradeData.upgradeCostValue.CurrentValue);

            return price;
        }

        private float GetCurrentLevelAttackDamage()
        {
            return weaponLevelUpgradeData.attackDamageIncreaseValue.CurrentValue;
        }

        public void UpgradeWeaponLevel()
        {
            if (weaponLevelUpgradeData.attackDamageIncreaseValue.UpgradeMaxed)
                DebugHelper.LogYellow("LEVEL MAXED");

            weaponLevelUpgradeData.upgradeCostValue.Upgrade();
            weaponLevelUpgradeData.attackDamageIncreaseValue.Upgrade();
        }

        #endregion
    }
}