using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFireRate.SkillRubberBullets
{
    [CreateAssetMenu(fileName = "RubberBullet", menuName = "Game/Skill/FireRate/RubberBullet", order = 0)]
    [InlineEditor]
    public class RubberBulletsDataSo : BaseSkillDataSo
    {
        public RubberBulletsData rubberBulletsData;
    }
}