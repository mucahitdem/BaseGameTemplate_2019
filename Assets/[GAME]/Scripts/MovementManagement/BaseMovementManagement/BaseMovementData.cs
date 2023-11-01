using System;

namespace Scripts.GameScripts.MovementManagement.BaseMovementManagement
{
    [Serializable]
    public class BaseMovementData
    {
        public CostAndValue[] moveSpeed;
        public float turnSpeed;
    }
}