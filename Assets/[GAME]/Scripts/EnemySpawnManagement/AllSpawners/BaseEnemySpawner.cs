using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameSystemRelatedScripts;
using Scripts.EnemyManagement;
using Scripts.GameScripts.EnemySpawnManagement;
using Scripts.GameScripts.EnvironmentManager;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.EnemySpawnManagement.AllSpawners
{
    public class BaseEnemySpawner : BaseComponent
    {
        private readonly Queue<Action> _actionsToDo = new Queue<Action>();
        private BuildingCollider[] _buildingCols;
        private bool _isInProcess;

        private bool _isInsideBuilding;
        private PlayerManager _playerManager;

        [SerializeField]
        private MinMaxValue radius;

        private BuildingCollider[] BuildingCols
        {
            get
            {
                if (_buildingCols == null)
                    _buildingCols = EnvironmentActionManager.getCols?.Invoke();

                return _buildingCols;
            }
        }

        protected virtual void Start()
        {
            _playerManager = GameManager.Instance.Player;
        }

        private void Update()
        {
            if (_actionsToDo.Count > 0 && !_isInProcess)
            {
                _isInProcess = true;
                _actionsToDo.Dequeue()?.Invoke();
            }
        }

        public virtual void SpawnEnemy(BaseEnemyManager enemy)
        {
            Enqueue(() =>
            {
                if (!enemy)
                    return;
                var posToSpawn = GetSpawnPosition(1);

                // DebugHelper.LogGreen("POS TO SPAWN : " + posToSpawn );
                // Time.timeScale = 0f;
                enemy.BasePoolItem.PullObjFromPool<BaseEnemyManager>(posToSpawn);
                _isInProcess = false;
            });
        }

        protected void SpawnEnemy(BaseEnemyManager[] enemies)
        {
            Enqueue(() =>
            {
                if (enemies == null)
                    return;
                var enemyToSpawn = GetRandomEnemy(enemies);
                var posToSpawn = GetSpawnPosition();
                enemyToSpawn.BasePoolItem.PullObjFromPool<BaseEnemyManager>(posToSpawn);
                _isInProcess = false;
            });
        }


        private void Enqueue(Action actionToEnqueue)
        {
            _actionsToDo.Enqueue(actionToEnqueue);
        }

        private Vector3 GetSpawnPosition(int i = 0)
        {
            _isInsideBuilding = true;

            var spawnPosition = Vector3.zero;

            while (_isInsideBuilding)
            {
                var randomAngle = Random.Range(0f, 2f * Mathf.PI);
                var randomRadius = radius.RandomFloat();
                var randomPos = new Vector3(randomRadius * Mathf.Cos(randomAngle), 0f,
                    randomRadius * Mathf.Sin(randomAngle));
                if (i == 1)
                    DebugHelper.LogYellow("RANDOM POS  : " + randomPos);
                spawnPosition = _playerManager.TransformOfObj.position + randomPos;


                _isInsideBuilding = false;
                foreach (var building in BuildingCols)
                    if (IsPointInsideCollider(spawnPosition, building.BoxCol))
                    {
                        _isInsideBuilding = true;
                        break;
                    }
            }

            return spawnPosition;
        }

        private BaseEnemyManager GetRandomEnemy(BaseEnemyManager[] enemies)
        {
            return enemies[Random.Range(0, enemies.Length)];
        }

        private bool IsPointInsideCollider(Vector3 point, Collider col)
        {
            if (col.bounds.Contains(point))
                return true;

            return false;
        }
    }
}