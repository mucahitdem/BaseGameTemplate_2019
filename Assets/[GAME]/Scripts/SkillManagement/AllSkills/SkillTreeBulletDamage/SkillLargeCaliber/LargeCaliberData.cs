using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeBulletDamage.SkillLargeCaliber
{
    [Serializable]
    public class LargeCaliberData
    {
        // ● + %35 Mermi Hasarı Artışı (Bullet Damage İncrease)
        // ● + %40 Mermi Boyutunda Büyüme (Bullet Size)
        // ● - % 16 Atış Sıklığında Azalma (Fire Rate Reduce)

        public float bulletDamageIncreasePercentage;
        public float bulletSizeIncreaseAmount;
        public float fireRateIncreasePercentage;
    }
}