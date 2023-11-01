using System;

namespace Scripts.GameScripts.PlayerManagement
{
    public static class PlayerActionManager
    {
        public static Action<int> gainHp;
        public static Action<int> gainMaxHp;
        public static Action<float> increasePlayerSizePercentage;

        public static Action onPlayerTakeDamage;
        public static Action onPlayerDied;
    }
}