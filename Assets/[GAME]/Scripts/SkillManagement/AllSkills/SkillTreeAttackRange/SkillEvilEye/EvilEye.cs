using Scripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAttackRange.SkillEvilEye
{
    public class EvilEye : BaseSkill
    {
        private EvilEyeDataSo _evilEyeDataSo;

        private EvilEyeDataSo EvilEyeDataSo
        {
            get
            {
                if (!_evilEyeDataSo)
                    _evilEyeDataSo = (EvilEyeDataSo) BaseSkillDataSo;
                return _evilEyeDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = EvilEyeDataSo.evilEyeData;
            var player = GameManager.Instance.Player;

            //player.Weapon.increaseFireRangePercentage?.Invoke(data.fireRangeIncreasePercentage);
        }
    }
}