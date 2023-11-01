using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAttackRange.SkillEagleSight
{
    public class EagleSight : BaseSkill
    {
        private EagleSightDataSo _eagleSightDataSo;

        private EagleSightDataSo EagleSightDataSo
        {
            get
            {
                if (!_eagleSightDataSo)
                    _eagleSightDataSo = (EagleSightDataSo) BaseSkillDataSo;
                return _eagleSightDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = EagleSightDataSo.eagleSightData;
            GameManager.Instance.Player.Weapon.increaseFireRangePercentage?.Invoke(data.fireRangeIncreasePercentage);
        }
    }
}