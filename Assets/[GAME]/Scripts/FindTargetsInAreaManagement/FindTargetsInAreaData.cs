using System;
using UnityEngine;

namespace Scripts.GameScripts.FindTargetsInAreaManagement
{
    [Serializable]
    public class FindTargetsInAreaData
    {
        public LayerMask layerMask;
        public int maxTargetCount;
        public float radius;
    }
}