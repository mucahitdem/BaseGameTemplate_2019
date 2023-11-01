using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.XpManagement;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeCollectRange.SkillJuryRigging
{
    public class JuryRigging : BaseSkill
    {
        private JuryRiggingDataSo _juryRiggingDataSo;

        private JuryRiggingDataSo JuryRiggingDataSoDataSo
        {
            get
            {
                if (!_juryRiggingDataSo)
                    _juryRiggingDataSo = (JuryRiggingDataSo) BaseSkillDataSo;

                return _juryRiggingDataSo;
            }
        }

        public override void UseSkill()
        {
            // + %15 collectible toplama alanında genişleme gerçekleşir.
            // + %15 saldırı menzilinde artış gerçekleşir.
            var data = JuryRiggingDataSoDataSo.juryRiggingData;
            XpCollectActionManager.increaseCollectRadiusPercentage?.Invoke(data.collectRangeIncreasePercentage);
            GameManager.Instance.Player.Weapon.increaseFireRangePercentage?.Invoke(data.attackRangeIncreasePercentage);
        }
    }
}