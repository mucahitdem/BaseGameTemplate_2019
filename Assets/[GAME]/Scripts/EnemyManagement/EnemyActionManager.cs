using System;
using Scripts.GameScripts;
using UnityEngine;

namespace Scripts.EnemyManagement
{
    public static class EnemyActionManager
    {
        public static Action<BaseEnemyManager> onEnemyGotDamage;

        public static Action<BaseEnemyManager> onEnemyDied;
        public static Action<Vector3, float, FireType> onEnemyDiedAtPosition;
        public static Action<Vector3, float> onEnemyDiedWithHp;
    }
}