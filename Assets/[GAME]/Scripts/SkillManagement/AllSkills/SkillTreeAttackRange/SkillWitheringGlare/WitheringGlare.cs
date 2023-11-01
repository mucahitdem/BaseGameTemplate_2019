using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.SkillHelpersManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAttackRange.SkillWitheringGlare
{
    public class WitheringGlare : BaseSkill
    {
        private WitheringGlareDataSo _witheringGlareDataSo;

        [SerializeField]
        private DealDamageInAttackRange dealDamageInAttackRange;

        private WitheringGlareDataSo WitheringGlareDataSo
        {
            get
            {
                if (!_witheringGlareDataSo)
                    _witheringGlareDataSo = (WitheringGlareDataSo) BaseSkillDataSo;
                return _witheringGlareDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = WitheringGlareDataSo.witheringGlareData;
            var player = GameManager.Instance.Player;

            player.Weapon.increaseFireRangePercentage?.Invoke(data.fireRangeIncreasePercentage);
            dealDamageInAttackRange.SetData(data.damagePercentage, data.damageTimeRate);
        }
    }
}