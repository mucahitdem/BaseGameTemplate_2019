using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.TimerManagement;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillHelpersManagement
{
    public class IncreaseBulletDamage : BaseComponent
    {
        private float _percentage;
        private PlayerManager _playerManager;

        [SerializeField]
        private Timer timer;

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
            timer.onTimerEnded += OnTimerEnded;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            timer.onTimerEnded -= OnTimerEnded;
        }


        public void SetData(float duration, float percentage, ref Action onActionRaised)
        {
            timer.UpdateInitialValue(duration);
            _percentage = percentage;
            onActionRaised += IncreaseBulletDamagePercentage;
        }

        private void IncreaseBulletDamagePercentage()
        {
            PlayerManager.Weapon.increaseBulletDamagePercentage?.Invoke(_percentage);
            timer.RestartTimer();
        }

        private void OnTimerEnded()
        {
            PlayerManager.Weapon.increaseBulletDamagePercentage?.Invoke(-_percentage);
        }
    }
}