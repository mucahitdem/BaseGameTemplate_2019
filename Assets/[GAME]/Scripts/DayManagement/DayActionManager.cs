using System;

namespace Scripts.DayManagement
{
    public class DayActionManager
    {
        public static Action<int> onMorningStarted;
        public static Action<int> onNightStarted;
    }
}