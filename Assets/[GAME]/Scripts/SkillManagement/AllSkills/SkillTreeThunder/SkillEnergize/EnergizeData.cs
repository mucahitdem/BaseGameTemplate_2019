using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeThunder.SkillEnergize
{
    [Serializable]
    public class EnergizeData
    {
        public float attackDamageIncreasePercentage = 100f; // 100
        //Yıldırımlar %20 ihtimal ile 2 kat hasar verir.

        public float possibilityToIncreaseDamage = 20f;
    }
}