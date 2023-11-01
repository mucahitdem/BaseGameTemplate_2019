using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeProjectiles.SkillFusillade
{
    public class Fusillade : BaseSkill
    {
        private FusilladeDataSo _fusilladeDataSo;

        private FusilladeDataSo FusilladeDataSo
        {
            get
            {
                if (!_fusilladeDataSo)
                    _fusilladeDataSo = (FusilladeDataSo) BaseSkillDataSo;
                return _fusilladeDataSo;
            }
            set => _fusilladeDataSo = value;
        }

        public override void UseSkill()
        {
            var data = FusilladeDataSo.fusilladeData;
            GameManager.Instance.Player.Weapon.increaseProjectileCount?.Invoke(data.projectileIncreaseAmount);
            GameManager.Instance.Player.Weapon.increaseBulletSpreadAmount?.Invoke(data.bulletSpreadIncreaseAmount);
            GameManager.Instance.Player.Weapon.increaseBulletDamagePercentage?.Invoke(
                data.bulletDamageIncreasePercentage);
            GameManager.Instance.Player.Weapon.increaseMaxBulletCountPercentage?.Invoke(
                data.ammoAmountIncreasePercentage);
        }
    }
}