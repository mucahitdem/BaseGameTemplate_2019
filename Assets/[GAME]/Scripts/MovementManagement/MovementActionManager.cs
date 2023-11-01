using System;

namespace Scripts.GameScripts.MovementManagement
{
    public static class MovementActionManager
    {
        public static Action<float, float> increaseMovementSpeedPercentageInDuration;
        public static Action<float> increaseMovementSpeedPercentage;
        public static Action<float> updateSpeed;
    }
}