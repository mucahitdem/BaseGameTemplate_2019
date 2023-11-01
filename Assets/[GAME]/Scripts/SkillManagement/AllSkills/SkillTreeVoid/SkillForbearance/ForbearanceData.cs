using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeVoid.SkillForbearance
{
    [Serializable]
    public class ForbearanceData
    {
        //Hiçlik ile ile öldürülen her 200 düşmanda için mermi hasarında %10 artış gerçekleşir.
        public float bulletDamageIncreasePercentage;
        public int enemyAmountToKill;
        public FireType fireType;
    }
}