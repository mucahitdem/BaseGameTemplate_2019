using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFrostDamage.SkillFrostbolt
{
    public class Frostbolt : BaseSkill
    {
        private FrostboltDataSo _frostboltDataSo;

        private FrostboltDataSo FrostboltDataSo
        {
            get
            {
                if (!_frostboltDataSo)
                    _frostboltDataSo = (FrostboltDataSo) BaseSkillDataSo;

                return _frostboltDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = FrostboltDataSo.frostboltData;
        }
    }
}