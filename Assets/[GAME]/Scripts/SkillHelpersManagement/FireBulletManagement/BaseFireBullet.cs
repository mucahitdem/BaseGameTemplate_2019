using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BulletManagement.AllBullets.BaseBulletManagement;
using Scripts.GameScripts.BulletManagement.AllBullets.BaseBulletManagement;
using Scripts.GameScripts.Helpers;
using UnityEngine;

namespace Scripts.GameScripts.SkillHelpersManagement.FireBulletManagement
{
    public sealed class BaseFireBullet : BaseComponent
    {
        private int _ammoAmount;
        private float _spreadAmount;

        [SerializeField]
        private BaseBullet bullet;

        public void SetData(int ammoCount, float spreadAmount)
        {
            _ammoAmount = ammoCount;
            _spreadAmount = spreadAmount;
        }

        public void FireBullet(float bulletDamage, float bulletSize, Vector3 createPos, Vector3 dir, FireType fireType)
        {
            var targetDir = dir;
            var dirs = VectorRotater.GenerateSpread(targetDir, _spreadAmount, _ammoAmount);

            if (_ammoAmount == 1)
            {
                CreateAndMoveBullet(bulletDamage, bulletSize, createPos, targetDir, fireType);
                return;
            }

            for (var i = 0; i < _ammoAmount; i++)
                CreateAndMoveBullet(bulletDamage, bulletSize, createPos, dirs[i], fireType);
        }


        private void CreateAndMoveBullet(float damage, float bulletSize, Vector3 createPos, Vector3 targetDir,
            FireType fireType)
        {
            var createdBullet = bullet.BasePoolItem.PullObjFromPool<BaseBullet>(createPos);
            createdBullet.TransformOfObj.LookAt(createPos + targetDir);
            createdBullet.SetData((int) damage, 0f, bulletSize, fireType, true, Color.red);
            createdBullet.SetTarget(targetDir);
        }
    }
}