using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeProjectiles.SkillTailGun
{
    [CreateAssetMenu(fileName = "TailGun", menuName = "Game/Skill/Projectiles/TailGun", order = 0)]
    [InlineEditor]
    public class TailGunDataSo : BaseSkillDataSo
    {
        public TailGunData tailGunData;
    }
}