using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeProjectiles.SkillCoupDeGrace
{
    [CreateAssetMenu(fileName = "CoupDeGrace", menuName = "Game/Skill/Projectiles/CoupDeGrace", order = 0)]
    [InlineEditor]
    public class CoupDeGraceDataSo : BaseSkillDataSo
    {
        public CoupDeGraceData coupDeGraceData;
    }
}