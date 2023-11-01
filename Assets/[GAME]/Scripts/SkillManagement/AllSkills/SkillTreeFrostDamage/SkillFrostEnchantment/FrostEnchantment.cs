using Scripts.GameManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFrostDamage.SkillFrostEnchantment
{
    public class FrostEnchantment : BaseSkill
    {
        private FrostEnchantmentDataSo _frostEnchantmentDataSo;

        private FrostEnchantmentDataSo FrostEnchantmentDataSo
        {
            get
            {
                if (!_frostEnchantmentDataSo)
                    _frostEnchantmentDataSo = (FrostEnchantmentDataSo) BaseSkillDataSo;

                return _frostEnchantmentDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = FrostEnchantmentDataSo.frostEnchantmentData;
            // GameManager.Instance.Player.Weapon.setFrostDuration?.Invoke(data.frostDuration);
            // GameManager.Instance.Player.Weapon.increaseFrostProbability?.Invoke(data.frostProbability);
        }
    }
}