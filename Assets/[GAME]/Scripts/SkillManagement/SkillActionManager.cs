using System;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.SkillManagement.SkillTreeManagement;
using Scripts.SkillManagement.SkillTreeManagement;

namespace Scripts.GameScripts.SkillManagement
{
    public static class SkillActionManager
    {
        public static Func<BaseSkillDataSo[]> getSkills;
        public static Action<BaseSkillTreeDataSo> upgradeSkill;

        public static Action<BaseSkillTreeDataSo[]> onSkillsSelected;
    }
}