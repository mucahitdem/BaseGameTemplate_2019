using System;
using UnityEngine;

namespace Scripts.GameScripts.BulletManagement.BaseBulletMovementManagement
{
    [Serializable]
    public class BaseBulletMovementData
    {
        [SerializeField]
        private float speed;

        public float Speed => speed;
    }
}