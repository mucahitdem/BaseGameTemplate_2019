using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeHealth.SkillRegeneration
{
    [CreateAssetMenu(fileName = "Regeneration", menuName = "Game/Skill/Health/Regeneration", order = 0)]
    public class RegenerationDataSo : BaseSkillDataSo
    {
        public RegenerationData regenerationData;
    }
}