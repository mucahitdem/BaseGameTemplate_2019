using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeRadioactive.SkillFireMastery
{
    public class FireMastery : BaseSkill
    {
        private FireMasteryDataSo _fireMasteryDataSo;

        private FireMasteryDataSo FireMasteryDataSo
        {
            get
            {
                if (!_fireMasteryDataSo)
                    _fireMasteryDataSo = (FireMasteryDataSo) BaseSkillDataSo;

                return _fireMasteryDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = FireMasteryDataSo.fireMasteryData;
        }
    }
}