using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFireRate.SkillEntrenched
{
    public class Entrenched : BaseSkill
    {
        private EntrenchedDataSo _entrenchedDataSo;

        public EntrenchedDataSo EntrenchedDataSo
        {
            get
            {
                if (!_entrenchedDataSo)
                    _entrenchedDataSo = (EntrenchedDataSo) BaseSkillDataSo;
                return _entrenchedDataSo;
            }
            set => _entrenchedDataSo = value;
        }

        public override void UseSkill()
        {
            var data = EntrenchedDataSo.entrenchedData;
            GameManager.Instance.Player.Weapon.notToWasteBulletProbability?.Invoke(data.notToWasteBulletProbability);
        }
    }
}