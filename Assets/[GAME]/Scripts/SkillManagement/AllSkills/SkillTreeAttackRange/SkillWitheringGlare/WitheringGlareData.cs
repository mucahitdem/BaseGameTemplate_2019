using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAttackRange.SkillWitheringGlare
{
    [Serializable]
    public class WitheringGlareData
    {
        public float damagePercentage;

        public float damageTimeRate;
        // + %15 saldırı menzilinde artış gerçekleşir.
        // Saldırı menzilindeki rakiplere her 3 saniyede bir saldırı hasarının %20'si kadar hasar verir

        public float fireRangeIncreasePercentage;
    }
}