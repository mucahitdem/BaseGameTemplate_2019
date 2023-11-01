using Scripts.EnemyManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFrostDamage.SkillColdMastery;
using Scripts.SkillHelpersManagement;
using UnityEngine;

namespace Scripts.SkillManagement.AllSkills.SkillTreeFrostDamage.SkillColdMastery
{
    public class ColdMastery : BaseSkill
    {
        private ColdMasteryData _coldMasteryData;
        private ColdMasteryDataSo _coldMasteryDataSo;

        [SerializeField]
        private DealDamageEnemies damageEnemies;


        private ColdMasteryDataSo ColdMasteryDataSo
        {
            get
            {
                if (!_coldMasteryDataSo)
                    _coldMasteryDataSo = (ColdMasteryDataSo) BaseSkillDataSo;

                return _coldMasteryDataSo;
            }
        }

        public override void UseSkill()
        {
            _coldMasteryData = ColdMasteryDataSo.coldMasteryData;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            EnemyActionManager.onEnemyDied += OnEnemyDied;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            EnemyActionManager.onEnemyDied -= OnEnemyDied;
        }

        private void OnEnemyDied(BaseEnemyManager enemyManager)
        {
            damageEnemies.DealDamage(enemyManager, _coldMasteryData.damageToDealAsPercentageToMaxHealth);
        }
    }
}