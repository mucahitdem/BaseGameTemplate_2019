using System;
using Sirenix.OdinInspector;

namespace Scripts
{
    [Serializable]
    public struct CostAndValue
    {
        [HorizontalGroup]
        public float value;

        [HorizontalGroup]
        public float cost;

        public CostAndValue(float val, float newCost)
        {
            value = val;
            cost = newCost;
        }
    }
}