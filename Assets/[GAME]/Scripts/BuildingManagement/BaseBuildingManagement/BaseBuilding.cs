using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.StatsManagement;
using Scripts.UpgradeManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BuildingManagement.BaseBuildingManagement
{
    public abstract class BaseBuilding : BaseComponent, IDamageable
    {
        [field: SerializeField]
        public BaseBuildingDataSo BaseBuildingDataSo { get; protected set;}

        [ShowInInspector]
        [ReadOnly]
        public bool IsBuilt { get; protected set;}
        
        [ShowInInspector]
        [ReadOnly]
        public bool IsDamaged { get; protected set; }
        
        [ShowInInspector]
        [ReadOnly]
        public bool IsDestroyed { get; protected set; }

        [SerializeField]
        private bool buildsInTime;

        [SerializeField]
        private int buildTimeInDays;

        [SerializeField]
        protected BuildingGfxManager buildingGfxManager;

        [SerializeField]
        protected BaseSimpleUpgradableData healthData;

        [SerializeField]
        private BaseStatsManager baseStatsManager;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            baseStatsManager.onDied += OnDied;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            baseStatsManager.onDied -= OnDied;
        }

        

        public virtual void Built()
        {
            IsBuilt = true;
            buildingGfxManager.EnableGfx();
        }
        public void TakeDamage(int amount)
        {
            IsDamaged = true;
            baseStatsManager.TakeDamage(amount);
        }
        
        
        private void OnDied(float damage)
        {
            IsDestroyed = true;
            buildingGfxManager.DestroyBuilding();
        }
    }
}