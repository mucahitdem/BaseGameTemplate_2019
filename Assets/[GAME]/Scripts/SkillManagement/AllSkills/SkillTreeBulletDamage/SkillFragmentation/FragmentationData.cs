using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeBulletDamage.SkillFragmentation
{
    [Serializable]
    public class FragmentationData
    {
        public int bulletCount = 3;
        public float bulletDamagePercentage;

        public float bulletSpreadAmount = 360f;
        // Düşmanlar yok edildikten sonra etraflarına 3 adet mermi
        // saçarlar.Bumermiler normal mermi hasarının % 10 luk kısmı
        // kadar hasar vermektedir.

        public FireType fireType;
    }
}