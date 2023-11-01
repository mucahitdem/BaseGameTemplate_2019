using System;
using UnityEngine;

namespace Scripts.BaseGameScripts.TimerManagement
{
    public sealed class Timer : MonoBehaviour
    {
        public Action onTimerEnded;

        [SerializeField]
        private TimerData timerData;
        
        public float PassedDurationRate => (timerData.timerValue - TimerValue) / timerData.timerValue; // returns between 0 - 1
        public bool IsRunning { get; private set; }
        private bool IsPaused { get; set; }

        private float TimerValue
        {
            get => _timerValue;
            set
            {
                if (Math.Abs(value - _timerValue) > .0001f)
                {
                    _timerValue = value;

                    if (IsTimerEnded()) OnTimerEnded();
                }
            }
        }
        private float timerValueOnPaused;
        private float _timerValue;

        private void Awake()
        {
            if (!timerData.restartManually) 
                RestartTimer();
        }

        private void Start()
        {
            if(IsRunning)
                TimerManager.Instance.AddNewTimer(this);
        }
        
        public void RestartTimer()
        {
            if (IsPaused)
                IsPaused = false;

            ResetTimer();
            StartTimer();
        }
        public void PausePlayTimer(bool pause)
        {
            IsPaused = pause;
            if (IsPaused)
                StopTimer();
            else
                StartTimer();
        }
        public void StopTimer()
        {
            IsRunning = false;
            TimerManager.Instance.RemoveTimer(this);
        }
        public void UpdateTimerValue(float newTimerValue)
        {
            timerData.timerValue = newTimerValue;
        }
        public void OnUpdate(float deltaTime)
        {
            TimerValue -= deltaTime;
        }

        
        
        private bool IsTimerEnded()
        {
            return _timerValue <= 0f;
        }
        private void OnTimerEnded()
        {
            onTimerEnded?.Invoke();

            if (timerData.isRepeating)
                ResetTimer();
            else
                StopTimer();
        }
        private void StartTimer()
        {
            IsRunning = true;
            if(TimerManager.Instance)
                TimerManager.Instance.AddNewTimer(this);
        }
        private void ResetTimer()
        {
            TimerValue = timerData.timerValue;
        }
    }
}