using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFireRate.SkillRubberBullets
{
    [Serializable]
    public class RubberBulletsData
    {
        public float bulletDamageIncreasePercentage;
        public float fireRateIncreasePercentage;
        public FireType fireType;
        public int ricochetingBulletCount = 1;
        public float ricochetingBulletSpreadAmount = 10f;

        // ● +1 Düşmandan mermi sekmesi
        // ● + %10 Mermi atış sıklığında artış
        // ● - %10 Mermi hasarında azalış
    }
}