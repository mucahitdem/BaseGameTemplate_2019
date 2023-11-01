using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFireRate.SkillEntrenched
{
    [CreateAssetMenu(fileName = "Entrenched", menuName = "Game/Skill/FireRate/Entrenched", order = 0)]
    [InlineEditor]
    public class EntrenchedDataSo : BaseSkillDataSo
    {
        public EntrenchedData entrenchedData;
    }
}