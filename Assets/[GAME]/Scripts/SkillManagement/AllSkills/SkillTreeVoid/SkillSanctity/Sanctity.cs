using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.PlayerManagement;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeVoid.SkillSanctity
{
    public class Sanctity : BaseSkill
    {
        private PlayerManager _playerManager;
        private SanctityDataSo _sanctityDataSo;

        private SanctityDataSo SanctityDataSo
        {
            get
            {
                if (!_sanctityDataSo)
                    _sanctityDataSo = (SanctityDataSo) BaseSkillDataSo;

                return _sanctityDataSo;
            }
        }

        private PlayerManager PlayerManager
        {
            get
            {
                if (!_playerManager)
                    _playerManager = GameManager.Instance.Player;
                return _playerManager;
            }
        }

        public override void UseSkill()
        {
            //var data = SanctityDataSo.sanctityData;
        }

        public int TryIncreaseDamage(int damage)
        {
            damage += (int) MathCalculations.CalculatePercentage(damage,
                SanctityDataSo.sanctityData.increasePercentage * PlayerManager.PlayerStatsManager.CurrentHealth);
            return damage;
        }
    }
}