using _GAME_.Scripts.GameScripts.SoundManagement;
using Scripts.BaseGameScripts.TimerManagement;
using Scripts.BulletManagement.AllBullets.BaseBulletManagement;
using Scripts.GameScripts.BulletManagement.AllBullets.BaseBulletManagement;
using Scripts.GameScripts.CharacterManagement;
using Scripts.GameScripts.Helpers;
using Scripts.WeaponManagement.Weapons;
using UnityEngine;

namespace Scripts.GameScripts.WeaponManagement.Weapons.WeaponTypes
{
    public class BasicWeapon : BaseWeapon
    {
        private BasicWeaponDataSo _basicWeaponDataSo;

        [SerializeField]
        private BaseBullet bullet;

        [SerializeField]
        private Timer fireTimer;

        protected override void Start()
        {
            base.Start();
            _basicWeaponDataSo = (BasicWeaponDataSo) weaponDataSo;
            UpdateFireTimer();
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


        protected override void FireABullet(BaseCharacterManager baseChar)
        {
            if (IsOutOfAmmo)
                return;

            base.FireABullet(baseChar);

            var targetDir = -(TransformOfObj.position - baseChar.TransformOfObj.position).normalized;
            var dirs = VectorRotater.GenerateSpread(targetDir, CurrentMaxAngle, CurrentProjectiles);
            eventQueue.Add(() => { onFired?.Invoke(targetDir, CurrentDamage, CurrentBulletDamage); }, " DENEME 3");

            if (dirs.Length == 1)
            {
                CreateAndMoveBullet(targetDir);
                return;
            }

            for (var i = 0; i < dirs.Length; i++)
                CreateAndMoveBullet(dirs[i]);
        }

        protected override void IncreaseFireRatePercentage(float percentage)
        {
            base.IncreaseFireRatePercentage(percentage);
            UpdateFireTimer();
        }


        private void UpdateFireTimer()
        {
            fireTimer.UpdateInitialValue(1f / CurrentFireRate);
        }

        private void OnTimerEnded()
        {
            if (IsOutOfAmmo)
                return;
            var target = targetToShoot?.Invoke();
            if (target)
            {
                onShootingState?.Invoke(target);
                SoundManager.Instance.PlayGlobalAudio(Defs.AUDIO_LASER_SHOT);
                FireABullet(target);
            }
        }

        private void CreateAndMoveBullet(Vector3 targetDir)
        {
            var createdBullet =
                bullet.BasePoolItem.PullObjFromPool<BaseBullet>(firePoint.position, firePoint.eulerAngles);
            createdBullet.SetData((int) CurrentBulletDamage, CurrentBulletSpeedIncreasePercentage, CurrentBulletSize,
                currentFireType, player != null, bulletColor, FrostDuration);
            createdBullet.SetTarget(targetDir);
        }
    }
}