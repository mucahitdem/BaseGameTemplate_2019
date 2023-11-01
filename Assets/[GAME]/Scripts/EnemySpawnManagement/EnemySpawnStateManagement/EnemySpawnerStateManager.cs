using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement.States;
using UnityEngine;

namespace Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement
{
    public class EnemySpawnerStateManager : BaseComponent
    {
        private BaseEnemySpawnState _currentEnemySpawnState;

        [SerializeField]
        private EnemySpawnStateTrigger enemySpawnStateTrigger;

        private void Awake()
        {
            enemySpawnStateTrigger.onNextStateTriggered += NextState;
        }

        private void NextState(BaseEnemySpawnState newState)
        {
            _currentEnemySpawnState?.OnExitState();

            _currentEnemySpawnState = newState;
            _currentEnemySpawnState?.OnEnterState();
        }
    }
}