using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.TimerManagement;
using Scripts.GameManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillHelpersManagement
{
    public class DealDamageInAttackRange : BaseComponent
    {
        private int _damage;

        private PlayerManager _playerManager;

        [SerializeField]
        private Timer burnTimer;

        [SerializeField]
        [ReadOnly]
        private float percentage;

        [SerializeField]
        [ReadOnly]
        private float timeRate;

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

        public void SetData(float newPercentage, float newTimeRate)
        {
            // percentage = newPercentage;
            // timeRate = newTimeRate;
            // _playerManager = GameManager.Instance.Player;
            // var playerDamage = _playerManager.Weapon.CurrentDamage;
            // _damage = (int) MathCalculations.CalculatePercentage(playerDamage, percentage);
            //
            // DebugHelper.LogGreen("PLAYER DAMAGE : " + playerDamage);
            // DebugHelper.LogGreen("PERCENTAGE : " + percentage);
            // DebugHelper.LogGreen("DAMAGE : " + _damage);
            //
            // burnTimer.UpdateInitialValue(timeRate);
            // burnTimer.RestartTimer();
        }

        private void OnTimerEnded()
        {
            var enemiesInRange = _playerManager.FindNearestTargetInArea.BaseCharacterManagers;
            DebugHelper.LogGreen("DAMAGE : " + _damage);
            for (var i = 0; i < enemiesInRange.Count; i++)
            {
                var currentEnemy = enemiesInRange[i];
                currentEnemy.TakeDamage(_damage, FireType.Flame);
            }
        }
    }
}