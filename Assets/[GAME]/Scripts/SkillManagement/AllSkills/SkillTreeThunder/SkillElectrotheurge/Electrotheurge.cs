using Scripts.EnemyManagement;
using Scripts.GameScripts.EnemyManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.SkillHelpersManagement.LightningManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeThunder.SkillElectrotheurge
{
    public class Electrotheurge : BaseSkill
    {
        private ElectrotheurgeDataSo _electrotheurgeDataSo;

        [SerializeField]
        private LightExplosion lightExplosion;

        private ElectrotheurgeDataSo ElectrotheurgeDataSo
        {
            get
            {
                if (!_electrotheurgeDataSo)
                    _electrotheurgeDataSo = (ElectrotheurgeDataSo) BaseSkillDataSo;

                return _electrotheurgeDataSo;
            }
        }

        public override void UseSkill()
        {
            var data = ElectrotheurgeDataSo.electrotheurgeData;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            EnemyActionManager.onEnemyDiedAtPosition += OnEnemyDiedAtPosition;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            EnemyActionManager.onEnemyDiedAtPosition -= OnEnemyDiedAtPosition;
        }

        private void OnEnemyDiedAtPosition(Vector3 arg1, float arg2, FireType arg3)
        {
            var lightExp = lightExplosion.BasePoolItem.PullObjFromPool<LightExplosion>(arg1);
            lightExp.PlayEffect();
        }

        public int TryIncreaseDamage(int damage)
        {
            damage += (int) MathCalculations.CalculatePercentage(damage,
                ElectrotheurgeDataSo.electrotheurgeData.lightningDamageIncreasePercentage);
            return damage;
        }
    }
}