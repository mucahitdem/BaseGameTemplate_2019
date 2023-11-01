using Scripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeBulletDamage.SkillPowerShot
{
    public class PowerShot : BaseSkill
    {
        private PowerShotDataSo _powerShotDataSo;

        private PowerShotDataSo PowerShotDataSo
        {
            get
            {
                if (!_powerShotDataSo)
                    _powerShotDataSo = (PowerShotDataSo) BaseSkillDataSo;
                return _powerShotDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = PowerShotDataSo.powerShotData;
            var player = GameManager.Instance.Player;

            //player.Weapon.increaseBulletDamagePercentage?.Invoke(data.bulletDamageIncreasePercentage);
        }
    }
}