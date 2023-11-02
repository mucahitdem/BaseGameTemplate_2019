using System;
using UnityEngine;

namespace Scripts.DayManagement
{
    public class DayManager : MonoBehaviour
    {
        private int CurrentMorningCount { get; set; }
        private int CurrentNightCount { get; set; }

        private IDayState _currentState;

        private void Awake()
        {
            CurrentMorningCount = 1;
            CurrentNightCount = 1;
        }

        public void SetState(IDayState dayState)// perk seçildikten sonra bu kısım başlayacak
        {
            _currentState?.OnStateExit();

            _currentState = dayState;
            if ((Type) _currentState == typeof(Night))
            {
                DayActionManager.onNightStarted?.Invoke(CurrentNightCount);
                CurrentNightCount++;
            }
            else if((Type) _currentState == typeof(Morning))
            {
                DayActionManager.onMorningStarted?.Invoke(CurrentMorningCount);
                CurrentMorningCount++;
            }
            _currentState.OnStateEnter();
        }
    }
}