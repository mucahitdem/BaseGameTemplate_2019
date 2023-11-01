using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeHealth.SkillVitality
{
    [CreateAssetMenu(fileName = "Vitality", menuName = "Game/Skill/Health/Vitality", order = 0)]
    public class VitalityDataSo : BaseSkillDataSo
    {
        public VitalityData vitalityData;
    }
}