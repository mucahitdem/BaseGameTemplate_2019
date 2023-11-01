using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeHealth.SkillBruiser
{
    [Serializable]
    public class BruiserData
    {
        // ● +2 can kazanılır.
        // ● Karakterin fiziki boyutunda + %50 artış gerçekleşir.
        // ● - %16 hareket hızında azalış gerçekleşir.

        public float charSizeIncreasePercentage;
        public int healthIncreaseAmount;
        public float moveSpeedIncreasePercentage;
    }
}