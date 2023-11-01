using System;

namespace Scripts.GameScripts.EnemyManagement.AiMovementManagement.BaseAiMovementManagement
{
    [Serializable]
    public class BaseAiMovementData
    {
        public float reachingDist;
        public CostAndValue[] speed;
    }
}