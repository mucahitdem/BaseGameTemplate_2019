using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeCollectRange.SkillJuryRigging
{
    [Serializable]
    public class JuryRiggingData
    {
        public float attackRangeIncreasePercentage;
        // ● + %15 collectible toplama alanında genişleme gerçekleşir.
        // ● + %15 saldırı menzilinde artış gerçekleşir.

        public float collectRangeIncreasePercentage;
    }
}