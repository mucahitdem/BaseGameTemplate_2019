using System;
using Scripts.UpdateManagement;
using UnityEngine;

namespace Scripts.TimerManagement
{
    public class Timer : MonoBehaviour, IUpdate
    {
        public Action onTimerEnded;

        [SerializeField]
        private TimerData timerData;
        
        public float PassedDurationRate => (timerData.timerValue - TimerValue) / timerData.timerValue; // returns between 0 - 1
        public float RemainedDurationRate => TimerValue / timerData.timerValue; // returns between 0 - 1

        public bool IsRunning { get; private set; }
        //private bool IsPaused { get; set; }

        public float TimerValue
        {
            get => _timerValue;
            private set
            {
                if (Math.Abs(value - _timerValue) > .0001f)
                {
                    _timerValue = value;

                    if (IsTimerEnded()) 
                        OnTimerEnded();
                }
            }
        }
        private float _timerValueOnPaused;
        private float _timerValue;

        private void Awake()
        {
            if (!timerData.restartManually) 
                RestartTimer();
        }
        private void Start()
        {
            if(IsRunning)
                UpdateManagerRegisterer.ModifyRegisterState(this, true);
        }
        
        public void RestartTimer()
        {
            // if (IsPaused)
            //     IsPaused = false;

            ResetTimer();
            StartTimer();
        }
        // public void PausePlayTimer(bool pause)
        // {
        //     IsPaused = pause;
        //     if (IsPaused)
        //         StopTimer();
        //     else
        //         StartTimer();
        // }
        public void StopTimer()
        {
            IsRunning = false;
            UpdateManagerRegisterer.ModifyRegisterState(this, false);
        }
        public void UpdateTimerValue(float newTimerValue)
        {
            timerData.timerValue = newTimerValue;
        }
        public void OnUpdate()
        {
            TimerValue -= Time.deltaTime;
        }
        
        
        private bool IsTimerEnded()
        {
            return _timerValue <= 0f;
        }
        protected virtual void OnTimerEnded()
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
            UpdateManagerRegisterer.ModifyRegisterState(this, true);
        }
        private void ResetTimer()
        {
            TimerValue = timerData.timerValue;
        }
    }
}