using System;
using Scripts.BaseGameScripts.SourceManagement;
using Scripts.UpgradeManagement;
using UnityEngine;

namespace Scripts.WeaponManagement.WeaponLevelAndRankManagement.RankManagement
{
    [Serializable]
    public class WeaponRankData
    {
        public BaseUpgradableData attackDamageIncreaseValue;
        public ColorNameAndMaxLevelAndPrice[] colorNameAndMaxLevels;
        public BaseUpgradableData maxLevel;
        public BaseSourceDataSo sourceType;
        public BaseUpgradableData upgradeCostValue;
    }

    [Serializable]
    public struct ColorNameAndMaxLevelAndPrice
    {
        public Color colorOfStage;
        public string nameOfStage;
    }
}