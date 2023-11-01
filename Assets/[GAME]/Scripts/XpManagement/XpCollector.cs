using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.FindTargetsInAreaManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.XpManagement
{
    public class XpCollector : BaseComponent
    {
        private PlayerManager _playerManager;

        private XpItem _xpItem;

        [SerializeField]
        private FindTargetsInArea findTargetsInArea;

        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            _playerManager = (PlayerManager) baseComponent;
        }


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            XpCollectActionManager.increaseCollectRadiusPercentage += IncreaseCollectRadiusPercentage;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            XpCollectActionManager.increaseCollectRadiusPercentage -= IncreaseCollectRadiusPercentage;
        }


        private void IncreaseCollectRadiusPercentage(float percentage)
        {
            var newRadius = findTargetsInArea.CurrentRadius +
                            MathCalculations.CalculatePercentage(findTargetsInArea.InitialRadius, percentage);
            //DebugHelper.LogYellow("XP COLLECT RADIUS : " + findTargetsInArea.CurrentRadius + " /// " + newRadius);
            findTargetsInArea.UpdateRadius(newRadius);
        }

        private void Update()
        {
            findTargetsInArea.Scan(TryCollectXp);
        }

        private void TryCollectXp(Collider col)
        {
            if (col.TryGetComponent(out _xpItem)) _xpItem.MoveToPlayer(_playerManager.TransformOfObj);
        }
    }
}