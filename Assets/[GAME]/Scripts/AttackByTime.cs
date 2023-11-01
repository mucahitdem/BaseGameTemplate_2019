using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.TimerManagement;
using UnityEngine;

namespace Scripts
{
    public class AttackByTime : BaseComponent
    {
        [SerializeField]
        private Timer attackTimer;

        public Action onAttack;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            attackTimer.onTimerEnded += OnTimerEnded;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            attackTimer.onTimerEnded -= OnTimerEnded;
        }

        private void OnTimerEnded()
        {
            onAttack?.Invoke();
        }
    }
}