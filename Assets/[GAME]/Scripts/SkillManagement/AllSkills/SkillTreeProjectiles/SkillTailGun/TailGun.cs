using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillHelpersManagement.FireBulletManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeProjectiles.SkillTailGun
{
    public class TailGun : BaseSkill
    {
        private PlayerManager _playerManager;
        private TailGunData _tailGunData;
        private TailGunDataSo _tailGunDataSo;

        [SerializeField]
        private BaseFireBullet fireBullet;


        private TailGunDataSo TailGunDataSo
        {
            get
            {
                if (!_tailGunDataSo)
                    _tailGunDataSo = (TailGunDataSo) BaseSkillDataSo;
                return _tailGunDataSo;
            }
            set => _tailGunDataSo = value;
        }

        public override void UseSkill()
        {
            if (!_playerManager)
                _playerManager = GameManager.Instance.Player;

            _tailGunData = TailGunDataSo.tailGunData;
            fireBullet.SetData(_tailGunData.bulletCount, _tailGunData.spreadAmount);
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

        private void OnFired(Vector3 dir, float currentDamage, float bulletDamage)
        {
            var weapon = _playerManager.Weapon;
            var fireDir = _playerManager.BaseRigUpdater.RigLookDir;
            var createPos = TransformOfObj.position + Vector3.up;
            fireBullet.FireBullet(bulletDamage, weapon.CurrentBulletSize, createPos, -fireDir, _tailGunData.fireType);
        }
    }
}