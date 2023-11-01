using System;
using Scripts.BaseGameScripts.TimerManagement;
using UnityEngine;

namespace Scripts.AttackManagement
{
    public class BaseAttackManager : MonoBehaviour
    {
        public Action attack;

        [SerializeField]
        private Timer attackTimer;

        private void OnEnable()
        {
            attackTimer.onTimerEnded += OnTimerEnded;
        }
        private void OnDisable()
        {
            attackTimer.onTimerEnded -= OnTimerEnded;
        }

        private void OnTimerEnded()
        {
            attack?.Invoke();
        }
    }
}