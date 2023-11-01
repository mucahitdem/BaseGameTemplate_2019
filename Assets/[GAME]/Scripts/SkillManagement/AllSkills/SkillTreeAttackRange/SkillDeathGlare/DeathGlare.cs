using Scripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAttackRange.SkillDeathGlare
{
    public class DeathGlare : BaseSkill
    {
        private DeathGlareDataSo _deathGlareDataSo;

        private DeathGlareDataSo DeathGlareDataSo
        {
            get
            {
                if (!_deathGlareDataSo)
                    _deathGlareDataSo = (DeathGlareDataSo) BaseSkillDataSo;
                return _deathGlareDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = DeathGlareDataSo.deathGlareData;
            var player = GameManager.Instance.Player;

            //player.Weapon.increaseFireRangePercentage?.Invoke(data.fireRangeIncreasePercentage);
        }
    }
}