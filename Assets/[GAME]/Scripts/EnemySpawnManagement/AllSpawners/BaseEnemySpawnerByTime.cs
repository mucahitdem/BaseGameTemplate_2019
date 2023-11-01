using Scripts.BaseGameScripts.TimerManagement;
using Scripts.EnemyManagement;
using UnityEngine;

namespace Scripts.EnemySpawnManagement.AllSpawners
{
    public class BaseEnemySpawnerByTime : BaseEnemySpawner
    {
        private BaseEnemyManager[] _enemies;

        [SerializeField]
        private Timer spawnTimer;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            spawnTimer.onTimerEnded += OnTimerEnded;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            spawnTimer.onTimerEnded -= OnTimerEnded;
        }


        public void SetData(BaseEnemyManager[] enemiesToSpawn, float timeRate)
        {
            _enemies = enemiesToSpawn;
            spawnTimer.UpdateInitialValue(timeRate);
            spawnTimer.RestartTimer();
        }


        private void OnTimerEnded()
        {
            SpawnEnemy(_enemies);
        }
    }
}