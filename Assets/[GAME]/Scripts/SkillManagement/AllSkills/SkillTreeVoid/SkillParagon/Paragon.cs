using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeVoid.SkillSanctity;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeVoid.SkillParagon
{
    public class Paragon : BaseSkill
    {
        private ParagonDataSo _paragonDataSo;
        private PlayerManager _playerManager;

        [SerializeField]
        private Sanctity sancity;

        private ParagonDataSo ParagonDataSo
        {
            get
            {
                if (!_paragonDataSo)
                    _paragonDataSo = (ParagonDataSo) BaseSkillDataSo;

                return _paragonDataSo;
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
            var data = ParagonDataSo.paragonData;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            _playerManager.Weapon.onOutOfAmmo += OnOutOfAmmo;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            _playerManager.Weapon.onOutOfAmmo -= OnOutOfAmmo;
        }

        private void OnOutOfAmmo(float currentDamage, float currentBulletDamage)
        {
            var damage =
                (int) MathCalculations.CalculatePercentage(currentDamage,
                    ParagonDataSo.paragonData.attackDamagePercentage);
            damage = TryIncreaseDamage(damage);
            DamageEnemiesInRange(damage);
        }

        private void DamageEnemiesInRange(int damage)
        {
            var enemiesInRange = PlayerManager.FindNearestTargetInArea.BaseCharacterManagers;
            if (enemiesInRange.Count == 0)
                return;
            for (var i = 0; i < enemiesInRange.Count; i++)
            {
                var currentEnemy = enemiesInRange[i];
                currentEnemy.TakeDamage(damage, FireType.Void);
            }
        }

        private int TryIncreaseDamage(int damage)
        {
            var skillSanctity = (Sanctity) SkillManager.GetSkill(sancity);
            if (skillSanctity) damage = skillSanctity.TryIncreaseDamage(damage);

            return damage;
        }
    }
}