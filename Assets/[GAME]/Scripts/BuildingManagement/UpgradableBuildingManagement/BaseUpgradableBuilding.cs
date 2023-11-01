using Scripts.BuildingManagement.BaseBuildingManagement;
using UnityEngine;

namespace Scripts.BuildingManagement.UpgradableBuildingManagement
{
    public class BaseUpgradableBuilding : BaseBuilding
    {
        private int Level { get; set; }

        
        [SerializeField]
        private int maxUpgradeCount;

        
        protected bool IsMaxed { get; private set; }

        public virtual void Upgrade()
        {
            if (IsMaxed)
                return;

            Level++;
            if (Level == maxUpgradeCount)
            {
                IsMaxed = true;
            }
        }
    }
}