using System;
using Scripts.GameScripts.Helpers;
using UnityEngine;

namespace Scripts.GameScripts.TimerManagement
{
    public abstract class CountDownTimer : MonoBehaviour
    {
        private int _minutes;
        private int _seconds;
        private string _time;

        private float _totalTime;
        public Action<float> onCurrentTimeUpdate;
        public Action<float> onSecondsPassedUpdate;
        public Action onTimeEnded;
        public Action<string> onTimeInMinutesUpdate;


        [SerializeField]
        private int totalMinutes = 12;

        public float TotalTime => totalMinutes;
        public float CurrentTime { get; private set; }

        public float PassedTime { get; private set; }

        protected virtual void Awake()
        {
            // Convert total minutes to seconds
            _totalTime = totalMinutes * 60.0f;
            CurrentTime = _totalTime;
        }

        protected virtual void Update()
        {
            if (IsTimeEnded())
            {
                CurrentTime = 0;
                onTimeEnded?.Invoke();
            }
            else
            {
                CurrentTime -= Time.deltaTime;
                PassedTime = _totalTime - PassedTime;
                onCurrentTimeUpdate?.Invoke(CurrentTime);
                onTimeInMinutesUpdate?.Invoke(SecondToMinuteConvert.GetFormattedTime(CurrentTime));
                onSecondsPassedUpdate?.Invoke(PassedTime);
            }
        }

        private bool IsTimeEnded()
        {
            return CurrentTime <= 0;
        }
    }
}