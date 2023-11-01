using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.UpgradeManagement
{
    [Serializable]
    public class UpgradeData
    {
        public float Cost => cost;
        public float Data => data;
        
        [SerializeField]
        [HorizontalGroup]
        private float cost;

        [SerializeField]
        [HorizontalGroup]
        private float data;
    }
}