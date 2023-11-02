using Scripts.BuildingManagement.UpgradableBuildingManagement;
using Scripts.DayManagement;
using UnityEngine;

namespace Scripts.BuildingManagement
{
    public abstract class BaseEconomyBuilding : BaseUpgradableBuilding
    {
        [SerializeField]
        protected float coinAmountToGain;
        
        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            DayActionManager.onMorningStarted += OnMorningStarted;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            DayActionManager.onMorningStarted -= OnMorningStarted;
        }

        protected abstract void OnMorningStarted(int morningCount);
    }
}