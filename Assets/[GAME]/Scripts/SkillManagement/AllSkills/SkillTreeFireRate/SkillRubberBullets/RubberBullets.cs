using Scripts.EnemyManagement;
using Scripts.GameManagement;
using Scripts.GameScripts.EnemyManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillHelpersManagement.FireBulletManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeFireRate.SkillRubberBullets
{
    public class RubberBullets : BaseSkill
    {
        private PlayerManager _playerManager;
        private RubberBulletsData _rubberBulletsData;
        private RubberBulletsDataSo _rubberBulletsDataSo;

        [SerializeField]
        private BaseFireBullet fireBullet;

        private RubberBulletsDataSo RubberBulletsDataSo
        {
            get
            {
                if (!_rubberBulletsDataSo)
                    _rubberBulletsDataSo = (RubberBulletsDataSo) BaseSkillDataSo;
                return _rubberBulletsDataSo;
            }
        }

        public override void UseSkill()
        {
            if (!_playerManager)
                _playerManager = GameManager.Instance.Player;

            _rubberBulletsData = RubberBulletsDataSo.rubberBulletsData;
            // GameManager.Instance.Player.Weapon.increaseFireRatePercentage?.Invoke(_rubberBulletsData.fireRateIncreasePercentage);
            // GameManager.Instance.Player.Weapon.increaseBulletDamagePercentage?.Invoke(_rubberBulletsData.bulletDamageIncreasePercentage);
            fireBullet.SetData(_rubberBulletsData.ricochetingBulletCount,
                _rubberBulletsData.ricochetingBulletSpreadAmount);
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

        private void OnEnemyDiedAtPosition(Vector3 pos, float damageTaken, FireType fireType)
        {
            // var weapon = _playerManager.Weapon;
            // var createPos = pos + Vector3.up;
            // fireBullet.FireBullet(weapon.CurrentBulletDamage, weapon.CurrentBulletSize, createPos,
            //     TransformOfObj.forward, _rubberBulletsData.fireType);
        }
    }
}