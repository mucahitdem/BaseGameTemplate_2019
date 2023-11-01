using Scripts.EnemyManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeRadioactive.SkillFireEnchantment;
using Scripts.SkillHelpersManagement;
using UnityEngine;

namespace Scripts.SkillManagement.AllSkills.SkillTreeRadioactive.SkillFireEnchantment
{
    public class FireEnchantment : BaseSkill
    {
        private FireEnchantmentData _fireEnchantmentData;
        private FireEnchantmentDataSo _fireEnchantmentDataSo;

        [SerializeField]
        private DealDamageWithTime dealDamageWithTime;

        private FireEnchantmentDataSo FireEnchantmentDataSo
        {
            get
            {
                if (!_fireEnchantmentDataSo)
                    _fireEnchantmentDataSo = (FireEnchantmentDataSo) BaseSkillDataSo;

                return _fireEnchantmentDataSo;
            }
        }

        public override void UseSkill()
        {
            _fireEnchantmentData = FireEnchantmentDataSo.fireEnchantmentData;
            dealDamageWithTime.SetInitialData(_fireEnchantmentData.attackDamagePercentage,
                _fireEnchantmentData.timeRate);
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            EnemyActionManager.onEnemyGotDamage += OnEnemyGotDamage;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            EnemyActionManager.onEnemyGotDamage -= OnEnemyGotDamage;
        }

        private void OnEnemyGotDamage(BaseEnemyManager enemyDamaged)
        {
            if (ProbabilityCalculator.CheckProbability(_fireEnchantmentData.firingBulletProbability))
                dealDamageWithTime.AddNewEnemy(enemyDamaged);
        }
    }
}