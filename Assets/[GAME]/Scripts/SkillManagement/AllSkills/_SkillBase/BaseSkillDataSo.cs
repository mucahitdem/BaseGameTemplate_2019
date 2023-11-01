using Scripts.GameScripts.DevHelperTools.SoCreator;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.SkillManagement.AllSkills._SkillBase
{
    [InlineEditor]
    public class BaseSkillDataSo : BaseScriptableObject
    {
        public BaseSkill baseSkill;
        public BaseSkillData baseSkillData;

        [Button]
        private void GetName()
        {
            baseSkillData.skillName = name;
        }
    }
}