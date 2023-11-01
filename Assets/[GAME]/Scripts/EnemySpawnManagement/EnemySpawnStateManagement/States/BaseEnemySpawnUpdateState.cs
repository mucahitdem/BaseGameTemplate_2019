using Scripts.BaseGameScripts.Helper;
using Scripts.EnemyManagement;
using Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement.States;
using UnityEngine;

namespace Scripts.EnemySpawnManagement.EnemySpawnStateManagement.States
{
    public class BaseEnemySpawnUpdateState : BaseEnemySpawnState
    {
        [SerializeField]
        private BaseEnemyManager[] enemiesToSpawn;

        [SerializeField]
        private float spawnRate;


        public override void OnEnterState()
        {
            DebugHelper.LogRed("UPDATE SPAWN TIMER");
            EnemySpawnActionManager.onUpdateSpawnRateAndEnemies?.Invoke(enemiesToSpawn, spawnRate);
        }

        public override void OnExitState()
        {
        }
    }
}