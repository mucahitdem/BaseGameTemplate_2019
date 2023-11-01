using Scripts.GameScripts.EnemyManagement.AiMovementManagement.BaseAiMovementManagement;
using Scripts.GameScripts.NavMeshManagement;
using Scripts.NavMeshManagement;
using UnityEngine;

namespace Scripts.GameScripts.EnemyManagement.AiMovementManagement.MovementTypes
{
    public class NavMeshAi : BaseAiMovement
    {
        [SerializeField]
        protected NavMeshAgentManager navMeshAgentManager;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            navMeshAgentManager.onReachedTarget += OnAiReachedTarget;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            navMeshAgentManager.onReachedTarget -= OnAiReachedTarget;
        }


        public override void OnUpdate()
        {
            navMeshAgentManager.MoveAndUpdateAnimator();
        }

        public override void OnFixedUpdate()
        {
        }

        private void OnAiReachedTarget()
        {
            SetIfReachedTarget(true);
        }
    }
}