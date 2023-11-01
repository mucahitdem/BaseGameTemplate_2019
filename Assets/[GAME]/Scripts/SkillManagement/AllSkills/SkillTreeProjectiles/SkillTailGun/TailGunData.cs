using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeProjectiles.SkillTailGun
{
    [Serializable]
    public class TailGunData
    {
        public int bulletCount;
        public FireType fireType;
        public float spreadAmount = 270f;
    }
}