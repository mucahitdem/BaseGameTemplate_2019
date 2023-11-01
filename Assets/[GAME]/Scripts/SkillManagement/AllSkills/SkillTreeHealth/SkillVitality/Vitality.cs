using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeHealth.SkillVitality
{
    public class Vitality : BaseSkill
    {
        private VitalityDataSo _vitalityDataSo;

        private VitalityDataSo VitalityDataSo
        {
            get
            {
                if (!_vitalityDataSo)
                    _vitalityDataSo = (VitalityDataSo) BaseSkillDataSo;
                return _vitalityDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = VitalityDataSo.vitalityData;
            PlayerActionManager.gainMaxHp?.Invoke(data.healthIncreaseAmount);
        }
    }
}