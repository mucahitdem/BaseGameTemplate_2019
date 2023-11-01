using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeMovement.SkillHighRider;

namespace Scripts.SkillManagement.AllSkills.SkillTreeMovement.SkillHighRider
{
    public class HighRider : BaseSkill
    {
        private HighRiderDataSo _highRiderDataSo;

        private HighRiderDataSo HighRiderDataSo
        {
            get
            {
                if (!_highRiderDataSo)
                    _highRiderDataSo = (HighRiderDataSo) BaseSkillDataSo;

                return _highRiderDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = HighRiderDataSo.highRiderData;
            //MovementActionManager.increaseMovementSpeedPercentage?.Invoke(data.movementSpeedIncreasePercentage);
            //GameManager.Instance.Player.Weapon.increaseBulletMovementSpeedPercentage?.Invoke(data.bulletSpeedIncreasePercentage);
        }
    }
}