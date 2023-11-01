using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.Helpers;
using Scripts.StatsManagement.StatsUiManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.StatsManagement
{
    public class BaseStatsManager : BaseComponent
    {       
        public Action<float> onDied;
        public Action<float, float> onHealthUpdate;
        public Action<bool> showUiBar;
        
        public float CurrentHealth { get; protected set; }
        public bool IsHealthFilled => CurrentHealth >= _initialHealth;

        [SerializeField]
        private bool useStatsBar;
        
        [ShowIf("useStatsBar")]
        [SerializeField]
        private StatsUiBar statsUiBar;

        protected float healthPercentage;

        private float _initialHealth;

        protected virtual void Start()
        {
            ResetHealth();
        }

        
        
        public void ResetHealth()
        {
            _initialHealth = 0;
            CurrentHealth = _initialHealth;
            ControlHealth(0);
            if(statsUiBar)
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