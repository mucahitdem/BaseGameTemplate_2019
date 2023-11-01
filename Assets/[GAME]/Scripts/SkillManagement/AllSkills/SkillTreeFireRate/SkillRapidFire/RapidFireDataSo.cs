using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFireRate.SkillRapidFire
{
    [CreateAssetMenu(fileName = "RapidFire", menuName = "Game/Skill/FireRate/RapidFire", order = 0)]
    [InlineEditor]
    public class RapidFireDataSo : BaseSkillDataSo
    {
        public RapidFireData rapidFireData;
    }
}