using UnityEngine;

namespace Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement.States
{
    public abstract class BaseEnemySpawnState : MonoBehaviour
    {
        public abstract void OnEnterState();
        public abstract void OnExitState();
    }
}