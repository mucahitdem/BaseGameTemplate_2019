using Scripts.EnemyManagement;
using Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement.States;
using UnityEngine;

namespace Scripts.EnemySpawnManagement.EnemySpawnStateManagement.States
{
    public class BaseOnlyOneEnemyCreateState : BaseEnemySpawnState
    {
        [SerializeField]
        protected BaseEnemyManager enemyToCreate;

        public override void OnEnterState()
        {
        }

        public override void OnExitState()
        {
        }
    }
}