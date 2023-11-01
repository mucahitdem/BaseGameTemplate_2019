using System;

namespace Scripts.GameScripts.XpManagement
{
    public static class XpCollectActionManager
    {
        public static Action<float> increaseCollectRadiusPercentage;
        public static Action<float> onCollectedXp;
    }
}