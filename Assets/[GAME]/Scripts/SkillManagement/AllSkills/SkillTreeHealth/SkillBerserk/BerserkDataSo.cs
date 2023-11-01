using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeHealth.SkillBerserk
{
    [CreateAssetMenu(fileName = "Berserk", menuName = "Game/Skill/Health/Berserk", order = 0)]
    public class BerserkDataSo : BaseSkillDataSo
    {
        public BerserkData berserkData;
    }
}