using Scripts.EnemySpawnManagement;
using Scripts.EnemySpawnManagement.EnemySpawnStateManagement.States;

namespace Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement.States
{
    public class StateElite : BaseOnlyOneEnemyCreateState
    {
        public override void OnEnterState()
        {
            base.OnEnterState();
            EnemySpawnActionManager.onCreateElite?.Invoke(enemyToCreate);
        }
    }
}