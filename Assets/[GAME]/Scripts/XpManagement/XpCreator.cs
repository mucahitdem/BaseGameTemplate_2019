using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.EnemyManagement;
using Scripts.GameScripts.EnemyManagement;
using UnityEngine;

namespace Scripts.GameScripts.XpManagement
{
    public class XpCreator : BaseComponent
    {
        [SerializeField]
        private XpItem xpItem;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            EnemyActionManager.onEnemyDiedWithHp += OnXpDropped;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            EnemyActionManager.onEnemyDiedWithHp -= OnXpDropped;
        }

        private void OnXpDropped(Vector3 posToCreate, float xpVal)
        {
            var createdXpSphere =
                xpItem.PoolItem
                    .PullObjFromPool<XpItem>(posToCreate);
            createdXpSphere.LoadXp(xpVal);
        }
    }
}