using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.EnemyManagement;
using Scripts.EnemySpawnManagement.AllSpawners;
using UnityEngine;

namespace Scripts.EnemySpawnManagement
{
    public class EnemySpawnManager : BaseComponent
    {
        [SerializeField]
        private BaseEnemySpawner enemySpawner;

        [SerializeField]
        private BaseEnemySpawnerByTime enemySpawnerByTime;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            EnemySpawnActionManager.onCreateBoss += OnCreateBoss;
            EnemySpawnActionManager.onCreateElite += OnCreateElite;
            EnemySpawnActionManager.onUpdateSpawnRateAndEnemies += OnUpdateSpawnRateAndEnemies;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            EnemySpawnActionManager.onCreateBoss -= OnCreateBoss;
            EnemySpawnActionManager.onCreateElite -= OnCreateElite;
            EnemySpawnActionManager.onUpdateSpawnRateAndEnemies -= OnUpdateSpawnRateAndEnemies;
        }

        private void OnUpdateSpawnRateAndEnemies(BaseEnemyManager[] enemies, float timeRate)
        {
            enemySpawnerByTime.SetData(enemies, timeRate);
        }

        private void OnCreateBoss(BaseEnemyManager boss)
        {
            enemySpawner.SpawnEnemy(boss);
        }

        private void OnCreateElite(BaseEnemyManager elite)
        {
            enemySpawner.SpawnEnemy(elite);
        }
    }
}