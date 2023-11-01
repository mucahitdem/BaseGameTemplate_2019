using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeProjectiles.SkillDoubleBarrel
{
    [CreateAssetMenu(fileName = "DoubleBarrel", menuName = "Game/Skill/Projectiles/DoubleBarrel", order = 0)]
    [InlineEditor]
    public class DoubleBarrelDataSo : BaseSkillDataSo
    {
        public DoubleBarrelData doubleBarrelData;
    }
}