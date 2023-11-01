using System;

namespace Scripts.GameScripts.StatsManagement.PlayerStatsManagement
{
    public static class PlayerStatsActionManager
    {
        public static Action<float, float> onHealthValueUpdated;
        public static Action<int> onMaxHpValueUpdated;

        public static Action<float, float> onXpValueChange;
        public static Action<int> onLevelChanged;
    }
}