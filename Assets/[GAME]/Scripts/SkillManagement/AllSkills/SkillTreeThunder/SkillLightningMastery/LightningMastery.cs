using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillHelpersManagement.LightningManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeThunder.SkillElectrotheurge;
using Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeThunder.SkillEnergize;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeThunder.SkillLightningMastery
{
    public class LightningMastery : BaseSkill
    {
        private LightningMasteryData _data;
        private int _firedBulletCount;
        private LightningMasteryDataSo _lightningMasteryDataSo;
        private PlayerManager _playerManager;

        [SerializeField]
        private Electrotheurge electrotheurge;

        [SerializeField]
        private Energize energize;

        [SerializeField]
        private LightningCreator lightningCreator;


        private LightningMasteryDataSo LightningMasteryDataSo
        {
            get
            {
                if (!_lightningMasteryDataSo)
                    _lightningMasteryDataSo = (LightningMasteryDataSo) BaseSkillDataSo;

                return _lightningMasteryDataSo;
            }
        }

        private PlayerManager PlayerManager
        {
            get
            {
                if (!_playerManager)
                    _playerManager = GameManager.Instance.Player;
                return _playerManager;
            }
        }

        public override void UseSkill()
        {
            _data = LightningMasteryDataSo.lightningMasteryData;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            GameManager.Instance.Player.Weapon.onFired += OnFired;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            GameManager.Instance.Player.Weapon.onFired -= OnFired;
        }

        private void OnFired(Vector3 bulletDirection, float attackDamage, float bulletDamage)
        {
            _firedBulletCount++;
            if (_firedBulletCount % _data.bulletAmountToTriggerLightning == 0)
            {
                var damage = (int) MathCalculations.CalculatePercentage(bulletDamage, _data.lightningDamagePercentage);
                var skillEnergize = (Energize) SkillManager.GetSkill(energize);
                if (skillEnergize) damage = skillEnergize.TryIncreaseDamage(damage);

                var skillElectrotheurge = (Electrotheurge) SkillManager.GetSkill(electrotheurge);
                if (skillElectrotheurge) damage = skillElectrotheurge.TryIncreaseDamage(damage);

                var enemiesInRange = PlayerManager.FindNearestTargetInArea.BaseCharacterManagers;
                if (enemiesInRange.Count == 0)
                    return;
                var randomEnemy = enemiesInRange[Random.Range(0, enemiesInRange.Count)];
                var lightning =
                    lightningCreator.BasePoolItem.PullObjFromPool<LightningCreator>(randomEnemy.TransformOfObj
                        .position);
                lightning.SetTarget(randomEnemy.TransformOfObj, damage,
                    () => { randomEnemy.TakeDamage(damage, FireType.Lightning); }, true);
            }
        }
    }
}