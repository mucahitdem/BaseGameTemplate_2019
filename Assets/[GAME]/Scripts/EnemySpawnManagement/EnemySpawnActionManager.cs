using System;
using Scripts.EnemyManagement;

namespace Scripts.EnemySpawnManagement
{
    public static class EnemySpawnActionManager
    {
        public static Action<BaseEnemyManager[], float> onUpdateSpawnRateAndEnemies;
        public static Action<BaseEnemyManager> onCreateElite;
        public static Action<BaseEnemyManager> onCreateBoss;
    }
}