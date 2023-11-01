using Scripts.BuildingManagement.BaseBuildingManagement;
using UnityEngine;

namespace Scripts.BuildingManagement.UpgradableBuildingManagement
{
    public class BaseUpgradableBuilding : BaseBuilding
    {
        protected bool IsMaxed { get; private set; }

        [SerializeField]
        private int maxUpgradeCount;
        
        private int Level { get; set; }

        protected virtual void Awake()
        {
            Level = 1;
            UpdateData();
        }

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

        protected virtual void UpdateData()
        {
            
        }
    }
}