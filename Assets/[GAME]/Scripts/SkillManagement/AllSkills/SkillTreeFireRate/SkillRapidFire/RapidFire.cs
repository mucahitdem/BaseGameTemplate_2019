using Scripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFireRate.SkillRapidFire
{
    public class RapidFire : BaseSkill
    {
        private RapidFireDataSo _rapidFireDataSo;

        private RapidFireDataSo RapidFireDataSo
        {
            get
            {
                if (!_rapidFireDataSo)
                    _rapidFireDataSo = (RapidFireDataSo) BaseSkillDataSo;
                return _rapidFireDataSo;
            }
            set => _rapidFireDataSo = value;
        }

        public override void UseSkill()
        {
            var data = RapidFireDataSo.rapidFireData;

            //GameManager.Instance.Player.Weapon.increaseFireRatePercentage?.Invoke(data.fireRateIncreasePercentage);
        }
    }
}