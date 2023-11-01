using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeCollectRange.SkillPerspicacity
{
    [Serializable]
    public class PerspicacityData
    {
        // + %15 collectible toplama alanında genişleme gerçekleşir.
        //  Her deneyim puanı toplandığı zaman 1 saniyeliğine + %35hareket hızı kazanılır.
        public float collectRangeIncreasePercentage;
        public float movementSpeedAmountGainedOnCollectedXp;
        public float movementSpeedDurationGainedOnCollectedXp;
    }
}