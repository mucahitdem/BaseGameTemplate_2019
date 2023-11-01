using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeProjectiles.SkillFusillade
{
    [CreateAssetMenu(fileName = "Fusillade", menuName = "Game/Skill/Projectiles/Fusillade", order = 0)]
    [InlineEditor]
    public class FusilladeDataSo : BaseSkillDataSo
    {
        public FusilladeData fusilladeData;
    }
}