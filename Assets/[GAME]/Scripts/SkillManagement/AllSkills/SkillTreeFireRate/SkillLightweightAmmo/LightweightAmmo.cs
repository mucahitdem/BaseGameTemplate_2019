using Scripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFireRate.SkillLightweightAmmo
{
    public class LightweightAmmo : BaseSkill
    {
        private LightweightAmmoDataSo _lightweightAmmoDataSo;

        private LightweightAmmoDataSo LightweightAmmoDataSo
        {
            get
            {
                if (!_lightweightAmmoDataSo)
                    _lightweightAmmoDataSo = (LightweightAmmoDataSo) BaseSkillDataSo;
                return _lightweightAmmoDataSo;
            }
            set => _lightweightAmmoDataSo = value;
        }

        public override void UseSkill()
        {
            var data = LightweightAmmoDataSo.doubleBarrelData;
            // GameManager.Instance.Player.Weapon.increaseFireRatePercentage?.Invoke(data.fireRateIncreasePercentage);
            // GameManager.Instance.Player.Weapon.increaseMaxBulletCount?.Invoke(data.maxAmmoIncreaseAmount);
            // GameManager.Instance.Player.Weapon.increaseBulletMovementSpeedPercentage?.Invoke(data.bulletMovementSpeedIncreasePercentage);
        }
    }
}