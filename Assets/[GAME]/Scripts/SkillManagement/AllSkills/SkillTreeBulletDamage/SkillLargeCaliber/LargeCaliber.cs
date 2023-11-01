using Scripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeBulletDamage.SkillLargeCaliber
{
    public class LargeCaliber : BaseSkill
    {
        private LargeCaliberDataSo _largeCaliberDataSo;

        private LargeCaliberDataSo LargeCaliberDataSo
        {
            get
            {
                if (!_largeCaliberDataSo)
                    _largeCaliberDataSo = (LargeCaliberDataSo) BaseSkillDataSo;
                return _largeCaliberDataSo;
            }
        }

        public override void UseSkill()
        {
            // var data = LargeCaliberDataSo.largeCaliberData;
            // GameManager.Instance.Player.Weapon.increaseBulletDamagePercentage?.Invoke(
            //     data.bulletDamageIncreasePercentage);
            // GameManager.Instance.Player.Weapon.increaseFireRatePercentage?.Invoke(data.fireRateIncreasePercentage);
            // GameManager.Instance.Player.Weapon.increaseBulletSizePercentage?.Invoke(data.bulletSizeIncreaseAmount);
        }
    }
}