using System;
using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoadManagement;
using Scripts.BaseGameScripts.TimerManagement;
using Scripts.GameScripts;
using Scripts.GameScripts.CharacterManagement;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.WeaponManagement.Weapons;
using Scripts.PlayerManagement;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.WeaponManagement.Weapons
{
    public abstract class BaseWeapon : BaseComponent, ISaveAndLoad
    {
        private BaseWeaponData _baseWeaponData;

        private int _currentAmmo;
        private float _initialBulletDamage;
        private float _notToWasteBulletProbability;
        private float _reloadDuration;

        [SerializeField]
        protected Color bulletColor;

        [SerializeField]
        protected FireType currentFireType;

        protected EventQueue eventQueue;

        public Action<int> fillAmmo;

        [SerializeField]
        protected Transform firePoint;

        public Action<float> increaseBulletDamagePercentage;
        public Action<float> increaseBulletMovementSpeedPercentage;
        public Action<float> increaseBulletSizePercentage;

        public Action<float> increaseBulletSpreadAmount;
        public Action<float> increaseFireRangePercentage;
        public Action<float> increaseFireRatePercentage;
        public Action<float> increaseFrostProbability;
        public Action<int> increaseMaxBulletCount;
        public Action<float> increaseMaxBulletCountPercentage;
        public Action<int> increaseProjectileCount;
        public Action<float> increaseReloadSpeedPercentage;


        [FormerlySerializedAs("isEnabled")]
        public bool isDisabled;

        public Action<float> notToWasteBulletProbability;
        public Action<int> onAmmoCountUpdated;
        public Action<Vector3, float, float> onFired;
        public Action<float> onFireRangeUpdated;
        public Action<float, float> onOutOfAmmo;
        public Action onReloadEnd;
        public Action<float> onReloadTimerUpdate;

        public Action<bool> onShootingState;
        protected BaseCharacterManager player;

        [SerializeField]
        private Timer reloadTimer;

        public Action<float> setFrostDuration;
        public Func<BaseCharacterManager> targetToShoot;
        public Action<float> updateDamage;

        [SerializeField]
        protected BaseWeaponDataSo weaponDataSo;
        // [SerializeField]
        // private WeaponEffectManager weaponEffectManager;

        public virtual BaseWeaponDataSo WeaponDataSo => weaponDataSo;
        //protected WeaponEffectManager WeaponEffectManager => weaponEffectManager;

        public float CurrentBulletSize { get; private set; }
        public float CurrentDamage { get; private set; }
        public float CurrentBulletDamage { get; private set; }
        protected float CurrentFireRate { get; private set; }
        protected int CurrentProjectiles { get; private set; }
        protected float CurrentMaxAngle { get; private set; }

        [field: SerializeField]
        protected float CurrentBulletSpeedIncreasePercentage { get; private set; }

        private float FrostProbability { get; set; }
        protected float FrostDuration { get; private set; }
        protected bool IsOutOfAmmo { get; private set; }
        private int CurrentMaxAmmo { get; set; }
        public float CurrentFireRange { get; private set; }

        public void Save()
        {
        }

        public void Load()
        {
            _baseWeaponData.Load();
            CurrentDamage = _baseWeaponData.GetCurrentAttackDamage();
            CurrentFireRate = _baseWeaponData.fireRate;
            CurrentProjectiles = _baseWeaponData.projectiles;
            CurrentMaxAmmo = _baseWeaponData.maxAmmo;
            UpdateBulletDamage();
            _currentAmmo = CurrentMaxAmmo;
            CurrentFireRange = _baseWeaponData.fireRange;
            CurrentMaxAngle = _baseWeaponData.maxAngle;
            _reloadDuration = _baseWeaponData.reloadDuration;

            UpdateReloadTimer();
            onAmmoCountUpdated?.Invoke(_currentAmmo);
            onFireRangeUpdated?.Invoke(CurrentFireRange);

            CurrentBulletSize = 1f;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            player = GetComponentInParent<PlayerManager>();
        }

        protected virtual void Start()
        {
            _baseWeaponData = weaponDataSo.baseWeaponData;
            Load();
            eventQueue = GameManager.Instance.EventQueue;
        }

        protected void Update()
        {
            if (reloadTimer && reloadTimer.IsRunning && !isDisabled)
                onReloadTimerUpdate?.Invoke(reloadTimer.PassedDurationRate);
        }


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            reloadTimer.onTimerEnded += MaxAmmo;
            increaseProjectileCount += IncreaseProjectileCount;
            increaseBulletDamagePercentage += IncreaseBulletDamagePercentage;
            increaseBulletSpreadAmount += IncreaseBulletSpreadAmount;
            increaseMaxBulletCount += IncreaseMaxBulletCount;
            increaseMaxBulletCountPercentage += IncreaseMaxBulletCountPercentage;
            increaseBulletMovementSpeedPercentage += IncreaseBulletMovementSpeedPercentage;
            increaseFireRatePercentage += IncreaseFireRatePercentage;
            notToWasteBulletProbability += NotToWasteBulletProbability;
            increaseFireRangePercentage += IncreaseFireRangePercentage;
            fillAmmo += FillAmmoProbability;
            increaseReloadSpeedPercentage += IncreaseReloadSpeedPercentage;
            increaseBulletSizePercentage += IncreaseBulletSizePercentage;
            increaseFrostProbability += IncreaseFrostProbability;
            setFrostDuration += SetFrostDuration;

            updateDamage += UpdateDamage;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            reloadTimer.onTimerEnded -= MaxAmmo;
            increaseProjectileCount -= IncreaseProjectileCount;
            increaseBulletDamagePercentage -= IncreaseBulletDamagePercentage;
            increaseBulletSpreadAmount -= IncreaseBulletSpreadAmount;
            increaseMaxBulletCount -= IncreaseMaxBulletCount;
            increaseMaxBulletCountPercentage -= IncreaseMaxBulletCountPercentage;
            increaseBulletMovementSpeedPercentage -= IncreaseBulletMovementSpeedPercentage;
            increaseFireRatePercentage -= IncreaseFireRatePercentage;
            notToWasteBulletProbability -= NotToWasteBulletProbability;
            increaseFireRangePercentage -= IncreaseFireRangePercentage;
            fillAmmo -= FillAmmoProbability;
            increaseReloadSpeedPercentage -= IncreaseReloadSpeedPercentage;
            increaseBulletSizePercentage -= IncreaseBulletSizePercentage;
            increaseFrostProbability -= IncreaseFrostProbability;
            setFrostDuration -= SetFrostDuration;

            updateDamage -= UpdateDamage;
        }


        protected virtual void FireABullet(BaseCharacterManager baseChar)
        {
            if (IsOutOfAmmo)
                //DebugHelper.LogRed("IS OUT OF AMMO");
                return;

            UpdateCurrentFireType();
            TryReload();
        }

        protected virtual void TryReload()
        {
            if (_notToWasteBulletProbability <= 0f || _notToWasteBulletProbability > 0f &&
                ProbabilityCalculator.CheckProbability(_notToWasteBulletProbability))
            {
                _currentAmmo--;
                onAmmoCountUpdated?.Invoke(_currentAmmo); //_weaponUi.SetAmmo(_currentAmmo));
                reloadTimer.RestartTimer();
                if (_currentAmmo <= 0)
                {
                    IsOutOfAmmo = true;
                    eventQueue.Add(() => { onOutOfAmmo?.Invoke(CurrentDamage, CurrentBulletDamage); }, "DENEME");
                }
            }
        }

        protected virtual void IncreaseFireRatePercentage(float percentage)
        {
            var newFireRate = CurrentFireRate +
                              MathCalculations.CalculatePercentage(_baseWeaponData.fireRate, percentage);
            //DebugHelper.LogYellow("FIRE RATE : " + CurrentFireRate + " /// " + newFireRate);
            CurrentFireRate = newFireRate;
        }


        private void UpdateDamage(float newDamage)
        {
            CurrentDamage = newDamage;
            _initialBulletDamage = (int) (CurrentDamage * _baseWeaponData.bulletDamage);
            CurrentBulletDamage = _initialBulletDamage;
            DebugHelper.LogRed("WEAPON DAMAGE : " + CurrentDamage);
        }

        private void SetFrostDuration(float newFrostDuration)
        {
            FrostDuration = newFrostDuration;
        }

        private void UpdateCurrentFireType()
        {
            if (FrostProbability > 0f)
            {
                if (ProbabilityCalculator.CheckProbability(FrostProbability))
                    currentFireType = FireType.Frost;
                else
                    currentFireType = FireType.Normal;
                return;
            }

            currentFireType = FireType.Normal;
        }

        private void IncreaseFrostProbability(float probability)
        {
            FrostProbability = probability;
        }

        private void IncreaseBulletSizePercentage(float percentage)
        {
            var newBulletSize =
                CurrentBulletSize + MathCalculations.CalculatePercentage(CurrentBulletSize, percentage);
            //DebugHelper.LogYellow("BULLET SIZE : " + CurrentBulletSize + " /// " + newBulletSize);
            CurrentBulletSize = newBulletSize;
        }

        private void IncreaseReloadSpeedPercentage(float percentage)
        {
            var newReloadDuration = _reloadDuration - MathCalculations.CalculatePercentage(_reloadDuration, percentage);
            DebugHelper.LogYellow("RELOAD DURATION : " + _reloadDuration + " /// " + newReloadDuration);
            _reloadDuration = newReloadDuration;
            UpdateReloadTimer();
        }

        private void FillAmmoProbability(int ammoCountToLoad)
        {
            _currentAmmo += ammoCountToLoad;
        }

        private void IncreaseFireRangePercentage(float percentage)
        {
            var newFireRange = CurrentFireRange + MathCalculations.CalculatePercentage(CurrentFireRange, percentage);
            DebugHelper.LogYellow("FIRE RANGE : " + CurrentFireRange + " /// " + newFireRange);
            CurrentFireRange = newFireRange;
            onFireRangeUpdated?.Invoke(CurrentFireRange);
        }

        private void NotToWasteBulletProbability(float probabilityPercentage)
        {
            _notToWasteBulletProbability = probabilityPercentage;
        }

        private void IncreaseBulletMovementSpeedPercentage(float percentage)
        {
            CurrentBulletSpeedIncreasePercentage += percentage;
        }

        private void IncreaseMaxBulletCountPercentage(float percentage)
        {
            var newMaxBulletCount = CurrentMaxAmmo + MathCalculations.CalculatePercentage(CurrentMaxAmmo, percentage);
            DebugHelper.LogYellow("MAX AMMO : " + CurrentMaxAmmo + " /// " + (int) newMaxBulletCount);
            CurrentMaxAmmo = (int) newMaxBulletCount;
        }

        private void IncreaseMaxBulletCount(int amount)
        {
            var newMaxBulletCount = CurrentMaxAmmo + amount;
            DebugHelper.LogYellow("MAX AMMO : " + CurrentMaxAmmo + " /// " + newMaxBulletCount);
            CurrentMaxAmmo = newMaxBulletCount;
        }

        private void IncreaseBulletSpreadAmount(float spreadAmount)
        {
            var newMaxAngle = CurrentMaxAngle + spreadAmount;
            DebugHelper.LogYellow("MAX ANGLE : " + CurrentMaxAngle + " /// " + newMaxAngle);
            CurrentMaxAngle = newMaxAngle;
        }

        private void IncreaseBulletDamagePercentage(float percentage)
        {
            var newBulletDamage = CurrentBulletDamage +
                                  MathCalculations.CalculatePercentage(CurrentBulletDamage, percentage);
            DebugHelper.LogYellow("BULLET DAMAGE : " + CurrentBulletDamage + " /// " + newBulletDamage);
            CurrentBulletDamage = newBulletDamage;
        }

        private void IncreaseProjectileCount(int count)
        {
            var newProjectiles = CurrentProjectiles + count;
            DebugHelper.LogYellow("PROJECTILE COUNT : " + CurrentProjectiles + " /// " + newProjectiles);
            CurrentProjectiles = newProjectiles;
        }

        private void UpdateReloadTimer()
        {
            reloadTimer.UpdateInitialValue(_reloadDuration);
        }

        private void UpdateBulletDamage()
        {
            _initialBulletDamage = (int) (CurrentDamage * _baseWeaponData.bulletDamage);
            CurrentBulletDamage = _initialBulletDamage;
        }

        private void MaxAmmo()
        {
            _currentAmmo = CurrentMaxAmmo;
            onAmmoCountUpdated?.Invoke(_currentAmmo);
            IsOutOfAmmo = false;
        }
    }
}