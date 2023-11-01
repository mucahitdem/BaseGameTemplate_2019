using Scripts.GameManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillHelpersManagement.FireBulletManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeProjectiles.SkillCoupDeGrace
{
    public class CoupDeGrace : BaseSkill
    {
        private CoupDeGraceData _coupDeGraceData;
        private CoupDeGraceDataSo _coupDeGraceDataSo;
        private PlayerManager _playerManager;

        [SerializeField]
        private BaseFireBullet fireBullet;

        private CoupDeGraceDataSo CoupDeGraceDataSo
        {
            get
            {
                if (!_coupDeGraceDataSo)
                    _coupDeGraceDataSo = (CoupDeGraceDataSo) BaseSkillDataSo;
                return _coupDeGraceDataSo;
            }
            set => _coupDeGraceDataSo = value;
        }

        public override void UseSkill()
        {
            if (!_playerManager)
                _playerManager = GameManager.Instance.Player;

            _coupDeGraceData = CoupDeGraceDataSo.coupDeGraceData;
            fireBullet.SetData(_coupDeGraceData.bulletCount, _coupDeGraceData.maxAngle);
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            //GameManager.Instance.Player.Weapon.onOutOfAmmo += OnOutOfAmmo;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            //GameManager.Instance.Player.Weapon.onOutOfAmmo -= OnOutOfAmmo;
        }


        private void OnOutOfAmmo(float currentDamage, float bulletDamage)
        {
            // var damage = MathCalculations.CalculatePercentage(bulletDamage, _coupDeGraceData.bulletDamagePercentage);
            // var createPos = TransformOfObj.position + Vector3.up;
            // fireBullet.FireBullet(damage, _playerManager.Weapon.CurrentBulletSize, createPos, TransformOfObj.forward, _coupDeGraceData.fireType);
        }
    }
}