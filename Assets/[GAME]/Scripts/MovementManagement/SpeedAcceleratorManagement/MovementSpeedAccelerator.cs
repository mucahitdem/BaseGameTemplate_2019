using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.TimerManagement;
using Scripts.GameScripts.MovementManagement.BaseMovementManagement;
using Scripts.MovementManagement.BaseMovementManagement;
using UnityEngine;

namespace Scripts.GameScripts.MovementManagement.SpeedAcceleratorManagement
{
    public class MovementSpeedAccelerator : BaseComponent
    {
        private BaseMovement _baseMovement;

        [SerializeField]
        private Timer acceleratorTimer;

        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            _baseMovement = (BaseMovement) baseComponent;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            MovementActionManager.increaseMovementSpeedPercentageInDuration +=
                IncreaseMovementSpeedPercentageInDuration;
            MovementActionManager.increaseMovementSpeedPercentage += IncreaseMovementSpeedPercentage;
            MovementActionManager.updateSpeed += UpdateSpeed;
            acceleratorTimer.onTimerEnded += OnTimerEnded;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            MovementActionManager.increaseMovementSpeedPercentageInDuration -=
                IncreaseMovementSpeedPercentageInDuration;
            MovementActionManager.increaseMovementSpeedPercentage -= IncreaseMovementSpeedPercentage;
            MovementActionManager.updateSpeed -= UpdateSpeed;
            acceleratorTimer.onTimerEnded -= OnTimerEnded;
        }


        private void UpdateSpeed(float newSpeed)
        {
            //_baseMovement.UpdateSpeed(newSpeed);
        }

        private void IncreaseMovementSpeedPercentage(float percentage)
        {
            _baseMovement.IncreaseSpeed(percentage);
        }

        private void IncreaseMovementSpeedPercentageInDuration(float percentage, float duration)
        {
            _baseMovement.IncreaseSpeedTemporary(percentage);
            acceleratorTimer.UpdateInitialValue(duration);
            acceleratorTimer.RestartTimer();
        }

        private void OnTimerEnded()
        {
            _baseMovement.ResetSpeed();
        }
    }
}