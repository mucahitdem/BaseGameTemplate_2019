using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeProjectiles.SkillDoubleBarrel
{
    public class DoubleBarrel : BaseSkill
    {
        private DoubleBarrelDataSo _doubleBarrelDataSo;

        private DoubleBarrelDataSo DoubleBarrelDataSo
        {
            get
            {
                if (!_doubleBarrelDataSo)
                    _doubleBarrelDataSo = (DoubleBarrelDataSo) BaseSkillDataSo;
                return _doubleBarrelDataSo;
            }
            set => _doubleBarrelDataSo = value;
        }

        public override void UseSkill()
        {
            var data = DoubleBarrelDataSo.doubleBarrelData;
            GameManager.Instance.Player.Weapon.increaseProjectileCount?.Invoke(data.projectileIncreaseCount);
            GameManager.Instance.Player.Weapon.increaseBulletSpreadAmount?.Invoke(data.bulletSpreadIncreaseAmount);
            GameManager.Instance.Player.Weapon.increaseBulletDamagePercentage?.Invoke(
                data.bulletDamageDecreasePercentage);
        }
    }
}