using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.StatsManagement.StatsUiManagement;
using UnityEngine;

namespace Scripts.GameScripts.StatsManagement
{
    public class BaseStatsManager : BaseComponent
    {
        private float _initialHealth;

        [SerializeField]
        protected BaseStatsDataSo baseStatsDataSo;

        protected float healthPercentage;
        public Action<float> onDied;
        public Action<float, float> onHealthUpdate;
        public Action<bool> showUiBar;

        [SerializeField]
        private StatsUiBar statsUiBar;

        public bool IsHealthFilled => CurrentHealth >= _initialHealth;


        public float CurrentHealth { get; protected set; }

        protected virtual void Start()
        {
            ResetHealth();
        }

        public void ResetHealth()
        {
            _initialHealth = baseStatsDataSo.baseStatsData.health[0].value;
            CurrentHealth = _initialHealth;
            ControlHealth(0);
            statsUiBar.ResetBar();
        }


        public void TakeDamage(float damage)
        {
            ControlHealth(-damage);

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDied(damage);
            }
        }

        public void UpgradeHealth(int healthIndex)
        {
            CurrentHealth = baseStatsDataSo.baseStatsData.health[healthIndex].value;
            ControlHealth(0);
        }

        public CostAndValue UpgradeHealthValues(int healthLevelIndex)
        {
            if (healthLevelIndex >= baseStatsDataSo.baseStatsData.health.Length)
                return new CostAndValue(-1, -1);
            return baseStatsDataSo.baseStatsData.health[healthLevelIndex];
        }

        public void TakeDamagePercentageOfMaxHealth(float percentage)
        {
            var calculatedDamage = MathCalculations.CalculatePercentage(_initialHealth, percentage);
            ControlHealth(-calculatedDamage);

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDied(calculatedDamage);
            }
        }


        protected virtual void ControlHealth(float amount)
        {
            CurrentHealth += amount;
            CalculateHealthPercentage();
            onHealthUpdate?.Invoke(CurrentHealth, healthPercentage);
        }

        protected virtual void OnDied(float damage)
        {
            onDied?.Invoke(damage);
        }

        private void CalculateHealthPercentage()
        {
            healthPercentage = CurrentHealth / _initialHealth;
        }
    }
}