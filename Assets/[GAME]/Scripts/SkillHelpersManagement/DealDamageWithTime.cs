using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.TimerManagement;
using Scripts.EnemyManagement;
using Scripts.GameManagement;
using Scripts.GameScripts;
using Scripts.GameScripts.Helpers;
using Scripts.PlayerManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.SkillHelpersManagement
{
    public class DealDamageWithTime : BaseComponent
    {
        private readonly List<BaseEnemyManager> _enemyManagers = new List<BaseEnemyManager>();
        private PlayerManager _playerManager;

        [SerializeField]
        private Timer burnTimer;

        [SerializeField]
        [ReadOnly]
        private float percentage;

        [SerializeField]
        [ReadOnly]
        private float timeRate;

        private PlayerManager PlayerManager
        {
            get
            {
                if (!_playerManager)
                    _playerManager = GameManager.Instance.Player;
                return _playerManager;
            }
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            burnTimer.onTimerEnded += OnTimerEnded;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            burnTimer.onTimerEnded -= OnTimerEnded;
        }

        public void AddNewEnemy(BaseEnemyManager enemyToAdd)
        {
            _enemyManagers.Add(enemyToAdd);
        }

        public void SetInitialData(float newPercentage, float newTimeRate)
        {
            percentage = newPercentage;
            timeRate = newTimeRate;
            burnTimer.UpdateTimerValue(timeRate);
            burnTimer.RestartTimer();
        }

        private void OnTimerEnded()
        {
            // var playerAttackDamage = PlayerManager.Weapon.CurrentDamage;
            // var damage = (int) MathCalculations.CalculatePercentage(playerAttackDamage, percentage);
            // DebugHelper.LogGreen("DEAL DAMAGE : " + damage);
            //
            // for (var i = 0; i < _enemyManagers.Count; i++)
            // {
            //     var currentEnemy = _enemyManagers[i];
            //     if (currentEnemy.IsDead)
            //     {
            //         _enemyManagers.Remove(currentEnemy);
            //         continue;
            //     }
            //
            //     currentEnemy.TakeDamage(damage, FireType.RadioActive);
            // }
        }
    }
}