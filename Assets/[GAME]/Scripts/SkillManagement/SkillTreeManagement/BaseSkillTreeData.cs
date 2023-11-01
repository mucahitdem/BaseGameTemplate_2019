using System;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.SkillManagement.SkillTreeManagement
{
    [Serializable]
    public class BaseSkillTreeData
    {
        public string saveKey;
        public BaseSkillDataSo[] skills;

        [ReadOnly]
        public int upgradeCount;

        public BaseSkillDataSo GetCurrentSkillToUpgrade()
        {
            return skills[upgradeCount];
        }
    }
}