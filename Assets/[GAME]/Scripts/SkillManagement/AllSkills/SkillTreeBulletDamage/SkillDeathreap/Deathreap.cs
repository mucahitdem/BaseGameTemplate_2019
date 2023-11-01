using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeBulletDamage.SkillDeathreap
{
    public class Deathreap : BaseSkill
    {
        private DeathreapDataSo _deathreapDataSo;

        private DeathreapDataSo DeathreapDataSo
        {
            get
            {
                if (!_deathreapDataSo)
                    _deathreapDataSo = (DeathreapDataSo) BaseSkillDataSo;
                return _deathreapDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = DeathreapDataSo.deathreapData;
            var player = GameManager.Instance.Player;
            player.Weapon.increaseBulletDamagePercentage?.Invoke(data.bulletDamageIncreasePercentage);
        }
    }
}