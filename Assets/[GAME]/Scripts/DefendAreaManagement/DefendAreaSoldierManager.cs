using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.EnemyManagement;
using Scripts.GameScripts.CharacterManagement;
using Scripts.GameScripts.EnemyManagement;
using Scripts.GameScripts.GameManagement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.DefendAreaManagement
{
    public class DefendAreaSoldierManager : BaseComponent
    {
        private bool _deletingSoldiers;
        private int _posIndex;

        [FormerlySerializedAs("_createdEnemy")]
        [SerializeField]
        [ReadOnly]
        private List<BaseEnemyManager> createdEnemy = new List<BaseEnemyManager>();

        [SerializeField]
        private List<EnemyTypeAndCount> enemiesToCreate = new List<EnemyTypeAndCount>();

        [SerializeField]
        private GameObject enemyCreateEffect;

        [SerializeField]
        private Transform[] enemyPositions;

        public Action OnAllEnemiesDied;

        public void EnableSoldiers()
        {
            if (createdEnemy == null)
                createdEnemy = new List<BaseEnemyManager>();
            if (createdEnemy.Count == 0)
                for (var i = 0; i < enemiesToCreate.Count; i++)
                {
                    var currentData = enemiesToCreate[i];
                    var enemyToCreate = (BaseEnemyManager) currentData.enemyType.baseCharacterData.baseCharacter;

                    for (var j = 0; j < currentData.count; j++)
                    {
                        if (_posIndex >= enemyPositions.Length)
                            _posIndex = 0;
                        var posToCreate = enemyPositions[_posIndex].position;
                        _posIndex++;
                        Instantiate(enemyCreateEffect, posToCreate, Quaternion.identity);
                        var enemy = enemyToCreate.BasePoolItem.PullObjFromPool<BaseEnemyManager>(posToCreate);
                        enemy.onDied += OnDied;
                        createdEnemy.Add(enemy);
                    }
                }
            else
                ControlSoldiers(true);
        }

        public void DisableAllSoldiers()
        {
            _deletingSoldiers = true;
            DebugHelper.LogRed("DELETE ALL SOLDIERS : " + createdEnemy.Count);
            for (var i = 0; i < createdEnemy.Count; i++)
            {
                var currentEnemy = createdEnemy[i];
                var pool = currentEnemy.BasePoolItem;
                DebugHelper.LogYellow("POOL : " + pool.name);
                currentEnemy.BasePoolItem.AddObjToPool(currentEnemy);
            }

            createdEnemy.Clear();
            _posIndex = 0;
        }

        private void OnDied(BaseCharacterManager charMan)
        {
            charMan.onDied -= OnDied;
            var enemyMan = (BaseEnemyManager) charMan;
            for (var i = 0; i < createdEnemy.Count; i++)
            {
                var currentEnemy = createdEnemy[i];
                if (currentEnemy == enemyMan)
                {
                    createdEnemy.Remove(currentEnemy);
                    break;
                }
            }

            if (createdEnemy.Count == 0) OnAllEnemiesDied?.Invoke();
        }

        // public void DisableSoldiers()
        // {
        //    ControlSoldiers(false);
        // }

        public void Attack()
        {
            for (var i = 0; i < createdEnemy.Count; i++)
            {
                var currentEnemy = createdEnemy[i];
                currentEnemy.SetTarget(GameManager.Instance.Player.TransformOfObj);
            }
        }

        public void Defend()
        {
            if (_deletingSoldiers)
                return;
            for (var i = 0; i < createdEnemy.Count; i++)
            {
                var currentEnemy = createdEnemy[i];
                currentEnemy.SetTarget(enemyPositions[i].position);
            }
        }

        private void ControlSoldiers(bool isActive)
        {
            for (var i = 0; i < createdEnemy.Count; i++)
            {
                var currentEnemy = createdEnemy[i];
                currentEnemy.Go.SetActive(isActive);
            }
        }
    }

    [Serializable]
    public struct EnemyTypeAndCount
    {
        public BaseEnemyManagerDataSo enemyType;
        public int count;
    }
}