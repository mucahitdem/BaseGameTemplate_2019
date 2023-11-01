using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeHealth.SkillRegeneration
{
    [Serializable]
    public class RegenerationData
    {
        //● Her 90 saniyede bir 1 adet can yenilenir.

        public int hpGainAmount;
        public float hpGainDuration;
    }
}