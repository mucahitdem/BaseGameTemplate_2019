using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameManagement;
using Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement.States;
using Scripts.GameScripts.TimerManagement;
using UnityEngine;

namespace Scripts.GameScripts.EnemySpawnManagement.EnemySpawnStateManagement
{
    public class EnemySpawnStateTrigger : BaseComponent
    {
        private int _currentIndex;
        private MinuteAndState _currentMinuteAndState;

        private GameTimer _gameTimer;
        private int _lastTimeRecorded;

        private bool _once;

        [SerializeField]
        private MinuteAndState[] minutesAnsStates;

        public Action<BaseEnemySpawnState> onNextStateTriggered;

        private void Start()
        {
            UpdateCurrentPassedDuration();
            _gameTimer = GameManager.Instance.GameTimer;
            _gameTimer.onCurrentTimeUpdate += OnCurrentTimeUpdate;
        }

        private void OnCurrentTimeUpdate(float currentTime)
        {
            if ((int) currentTime == _lastTimeRecorded)
                return;
            _lastTimeRecorded = (int) currentTime;
            if (_lastTimeRecorded <= _currentMinuteAndState.minuteToTrigger)
            {
                _currentIndex++;
                UpdateCurrentPassedDuration();
            }
        }

        private void UpdateCurrentPassedDuration()
        {
            _currentMinuteAndState = minutesAnsStates[_currentIndex];
            _currentMinuteAndState.minuteToTrigger = ConvertTimeToSeconds(_currentMinuteAndState.minuteToTrigger);
            onNextStateTriggered?.Invoke(_currentMinuteAndState.state);
            if (IsLastState() && _gameTimer)
                _gameTimer.onCurrentTimeUpdate -= OnCurrentTimeUpdate;
        }

        private bool IsLastState()
        {
            return _currentIndex == minutesAnsStates.Length - 1;
        }

        private float ConvertTimeToSeconds(float timeValue)
        {
            var minutes = Mathf.FloorToInt(timeValue);
            var seconds = (timeValue - minutes) * 60.0f;
            return minutes * 60.0f + seconds;
        }
    }
}