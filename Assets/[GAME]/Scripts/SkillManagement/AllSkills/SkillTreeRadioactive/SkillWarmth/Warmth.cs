using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeRadioactive.SkillWarmth
{
    public class Warmth : BaseSkill
    {
        private WarmthDataSo _warmthDataSo;

        private WarmthDataSo WarmthDataSo
        {
            get
            {
                if (!_warmthDataSo)
                    _warmthDataSo = (WarmthDataSo) BaseSkillDataSo;

                return _warmthDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = WarmthDataSo.warmthData;
        }
    }
}