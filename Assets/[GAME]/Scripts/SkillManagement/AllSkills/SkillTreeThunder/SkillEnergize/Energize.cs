using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeThunder.SkillEnergize
{
    public class Energize : BaseSkill
    {
        private EnergizeDataSo _energizeDataSo;

        private EnergizeDataSo EnergizeDataSo
        {
            get
            {
                if (!_energizeDataSo)
                    _energizeDataSo = (EnergizeDataSo) BaseSkillDataSo;

                return _energizeDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = EnergizeDataSo.energizeData;
        }

        public int TryIncreaseDamage(int damage)
        {
            if (ProbabilityCalculator.CheckProbability(EnergizeDataSo.energizeData.possibilityToIncreaseDamage))
                return damage + (int) MathCalculations.CalculatePercentage(damage,
                    EnergizeDataSo.energizeData.attackDamageIncreasePercentage);
            return damage;
        }
    }
}