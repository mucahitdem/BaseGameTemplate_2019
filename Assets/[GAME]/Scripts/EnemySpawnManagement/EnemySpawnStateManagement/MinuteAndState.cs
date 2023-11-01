using System;
using Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement.States;

namespace Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement
{
    [Serializable]
    public class MinuteAndState
    {
        public float minuteToTrigger;
        public BaseEnemySpawnState state;
    }
}