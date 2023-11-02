using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.TimerManagement;
using Scripts.BulletManagement.AllBullets.BaseBulletManagement;
using Scripts.CharacterManagement;
using Scripts.EnemyManagement;
using Scripts.GameScripts;
using Scripts.GameScripts.BulletManagement.AllBullets;
using Scripts.GameScripts.FindTargetsInAreaManagement;
using Scripts.GameScripts.TurretManagement;
using UnityEngine;

namespace Scripts.TurretManagement
{
    public class Turret : BaseComponent
    {
        [Header("Use Bullets (default)")]
        public BasicBullet bullet;

        private int bulletDamage;
        private float bulletSpeedIncreaseAmount;
        private Vector3 dir;

        [SerializeField]
        private FindNearestTargetInArea findNearestTargetInArea;

        [SerializeField]
        private Transform[] firePoint;

        [SerializeField]
        private Timer fireTimer;

        [SerializeField]
        private Transform gfx;

        [SerializeField]
        private Transform partToRotate;

        private BaseCharacterManager tempTarget;

        [SerializeField]
        private float turnSpeed = 10f;

        protected override void OnEnable()
        {
            base.OnEnable();
            var data = TurretDataSo.Instance;
            bulletDamage = data.bulletDamage;
            bulletSpeedIncreaseAmount = data.bulletSpeedIncreaseAmount;
            fireTimer.RestartTimer();
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            fireTimer.onTimerEnded += OnTimerEnded;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            fireTimer.onTimerEnded -= OnTimerEnded;
        }


        private void Update()
        {
            if (Time.frameCount % 5 == 0)
            {
                tempTarget = findNearestTargetInArea.FindNearestChar<BaseEnemyManager>();
                if (tempTarget)
                    LockOnTarget();
            }
        }

        private void OnTimerEnded()
        {
            if (!tempTarget)
                return;
            Shoot();
        }

        private void LockOnTarget()
        {
            var dir = tempTarget.TransformOfObj.position - transform.position;
            var lookRotation = Quaternion.LookRotation(dir);
            var rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }


        private void Shoot()
        {
            for (var i = 0; i < firePoint.Length; i++)
            {
                var direction = -(firePoint[i].position - tempTarget.TransformOfObj.position);
                var createdBullet =
                    bullet.BasePoolItem.PullObjFromPool<BaseBullet>(firePoint[i].position, firePoint[i].eulerAngles);
                createdBullet.SetData(bulletDamage, bulletSpeedIncreaseAmount, 1, FireType.Normal, true, Color.red);
                direction.y = 0;
                createdBullet.SetTarget(direction);
            }
        }
    }
}