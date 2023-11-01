using Scripts.EnemySpawnManagement;
using Scripts.EnemySpawnManagement.EnemySpawnStateManagement.States;

namespace Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement.States
{
    public class StateBoss : BaseOnlyOneEnemyCreateState
    {
        public override void OnEnterState()
        {
            EnemySpawnActionManager.onCreateBoss?.Invoke(enemyToCreate);
        }
    }
}