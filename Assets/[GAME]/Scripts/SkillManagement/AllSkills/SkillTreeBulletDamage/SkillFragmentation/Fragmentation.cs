using Scripts.EnemyManagement;
using Scripts.GameScripts.EnemyManagement;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillHelpersManagement.FireBulletManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeBulletDamage.SkillFragmentation
{
    public class Fragmentation : BaseSkill
    {
        private FragmentationData _fragmentationData;
        private FragmentationDataSo _fragmentationDataSo;
        private PlayerManager _playerManager;

        [SerializeField]
        private BaseFireBullet fireBullet;

        private FragmentationDataSo FragmentationDataSo
        {
            get
            {
                if (!_fragmentationDataSo)
                    _fragmentationDataSo = (FragmentationDataSo) BaseSkillDataSo;
                return _fragmentationDataSo;
            }
        }

        public override void UseSkill()
        {
            if (!_playerManager)
                _playerManager = GameManager.Instance.Player;

            _fragmentationData = FragmentationDataSo.fragmentationData;
            fireBullet.SetData(_fragmentationData.bulletCount, _fragmentationData.bulletSpreadAmount);
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
            var damage = MathCalculations.CalculatePercentage(_playerManager.Weapon.CurrentBulletDamage,
                _fragmentationData.bulletDamagePercentage);
            var createPos = pos + Vector3.up;
            fireBullet.FireBullet(damage, _playerManager.Weapon.CurrentBulletSize, createPos, TransformOfObj.forward,
                _fragmentationData.fireType);
        }
    }
}