using Scripts.GameManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillHelpersManagement.LightningManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeThunder.SkillRicochetingLightning
{
    public class RicochetingLightning : BaseSkill
    {
        private PlayerManager _playerManager;
        private RicochetingLightningDataSo _ricochetingLightningDataSo;

        [SerializeField]
        private LightningCreator lightningCreator;

        private RicochetingLightningDataSo RicochetingLightningDataSo
        {
            get
            {
                if (!_ricochetingLightningDataSo)
                    _ricochetingLightningDataSo = (RicochetingLightningDataSo) BaseSkillDataSo;

                return _ricochetingLightningDataSo;
            }
        }

        private RicochetingLightningData RicochetingLightningData =>
            RicochetingLightningDataSo.ricochetingLightningData;

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
            var data = RicochetingLightningDataSo.ricochetingLightningData;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            LightningActionManager.onLightningRicocheted += OnLightningRicocheted;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            LightningActionManager.onLightningRicocheted -= OnLightningRicocheted;
        }

        private void OnLightningRicocheted(Vector3 startPos, int damage)
        {
            var enemiesInRange = PlayerManager.FindNearestTargetInArea.BaseCharacterManagers;
            if (enemiesInRange.Count <= 0)
                return;
            for (var i = 0; i < RicochetingLightningData.enemyAmountToRicochet; i++)
            {
                if (i >= enemiesInRange.Count)
                    break;
                var currentEnemy = enemiesInRange[i];
                var lightning = lightningCreator.BasePoolItem.PullObjFromPool<LightningCreator>(startPos + Vector3.up);
                lightning.SetTarget(currentEnemy.TransformOfObj, damage,
                    () => { currentEnemy.TakeDamage(damage, FireType.Lightning); });
            }
        }
    }
}