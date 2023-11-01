using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeProjectiles.SkillCoupDeGrace
{
    [Serializable]
    public class CoupDeGraceData
    {
        public int bulletCount = 10;

        public float bulletDamagePercentage = 15f;

        //● Şarjör bittiğinde etrafa %15 Mermi hasarı veren 10 ek mermi ateşlenir
        public FireType fireType;
        public float maxAngle = 360f;
    }
}