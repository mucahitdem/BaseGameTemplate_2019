using System;
using Scripts.BaseGameScripts.SourceManagement;

namespace Scripts.GameScripts.SourceManagement
{
    public static class SourceActionManager
    {
        public static Action<int, BaseSourceDataSo> addSource;
        public static Func<int, BaseSourceDataSo, bool> trySpendSource;
        public static Func<BaseSourceDataSo, int> getCurrentSource;

        public static Action<int> onSourceUpdated;
        public static Action<int, int> onClampedSourceUpdated;
    }
}