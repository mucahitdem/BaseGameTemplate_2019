using System;
using UnityEngine;

namespace Scripts.GameScripts.SendRayManagement
{
    [Serializable]
    public class SendRayData
    {
        public LayerMask layerMask;
        public float rayLength;
        public Transform rayStartPoint;
    }
}