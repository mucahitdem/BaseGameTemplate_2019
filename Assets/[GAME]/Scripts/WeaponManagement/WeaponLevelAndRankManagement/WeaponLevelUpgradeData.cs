using System;
using Scripts.BaseGameScripts.SourceManagement;
using Scripts.UpgradeManagement;

namespace Scripts.WeaponManagement.WeaponLevelAndRankManagement
{
    [Serializable]
    public class WeaponLevelUpgradeData
    {
        public BaseUpgradableData attackDamageIncreaseValue;
        public BaseSourceDataSo sourceType;
        public BaseUpgradableData upgradeCostValue;
    }
}