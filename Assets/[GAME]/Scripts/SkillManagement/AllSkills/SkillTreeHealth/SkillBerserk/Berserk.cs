using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillHelpersManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeHealth.SkillBerserk
{
    public class Berserk : BaseSkill
    {
        private BerserkDataSo _berserkDataSo;

        [SerializeField]
        private IncreaseBulletDamage increaseBulletDamage;

        private BerserkDataSo BerserkDataSo
        {
            get
            {
                if (!_berserkDataSo)
                    _berserkDataSo = (BerserkDataSo) BaseSkillDataSo;
                return _berserkDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = BerserkDataSo.berserkData;
            increaseBulletDamage.SetData(data.durationToGainBulletDamage, data.bulletDamageIncreasePercentage,
                ref PlayerActionManager.onPlayerTakeDamage);
        }
    }
}