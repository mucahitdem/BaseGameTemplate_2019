using Scripts.GameScripts.MovementManagement;
using Scripts.GameScripts.SkillHelpersManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeMovement.SkillPyromaniac
{
    public class Pyromaniac : BaseSkill
    {
        private PyromaniacDataSo _pyromaniacDataSo;

        [SerializeField]
        private DealDamageInAttackRange dealDamageInAttackRange;

        private PyromaniacDataSo PyromaniacDataSo
        {
            get
            {
                if (!_pyromaniacDataSo)
                    _pyromaniacDataSo = (PyromaniacDataSo) BaseSkillDataSo;

                return _pyromaniacDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = PyromaniacDataSo.pyromaniacData;
            MovementActionManager.increaseMovementSpeedPercentage?.Invoke(data.movementSpeedIncreasePercentage);
            dealDamageInAttackRange.SetData(data.burnDamagePercentage, data.burnRate);
        }
    }
}