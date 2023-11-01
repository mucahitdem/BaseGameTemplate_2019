using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoadManagement;
using Scripts.GameScripts;
using Scripts.GameScripts.StatsManagement;
using Scripts.GameScripts.StatsManagement.PlayerStatsManagement;
using UnityEngine;

namespace Scripts.StatsManagement.PlayerStatsManagement
{
    public class PlayerStatsManager : BaseStatsManager, ISaveAndLoad
    {
        private int _currentMaxHp;
        private float _healthIncreaseSpeed;

        private float _nextLevelXpValue;
        private PlayerStatsDataSo _playerStatsDataSo;
        private float _totalRequiredXp;
        private float _xpPercentage;

        private PlayerStatsDataSo PlayerStatsDataSo
        {
            get
            {
                if (!_playerStatsDataSo)
                    _playerStatsDataSo = (PlayerStatsDataSo) baseStatsDataSo;

                return _playerStatsDataSo;
            }
        }

        private int Level { get; set; }
        private float Xp { get; set; }

        public void Save()
        {
            PlayerPrefs.SetInt(Defs.SAVE_KEY_PLAYER_LEVEL, Level);
            PlayerPrefs.SetFloat(Defs.SAVE_KEY_PLAYER_XP, Xp);
        }

        public void Load()
        {
        }

        protected override void Start()
        {
            base.Start();
            Load();
            //CalculateRequiredXp();

            // OnMaxHealthUpdatedSendEvent();
            // OnHealthUpdatedSendEvent();
            // OnLevelUpdatedSendEvent();
            // OnXpUpdatedSendEvent();
        }


        public void GainHealth(int healthToIncrease)
        {
            ControlHealth(healthToIncrease);
        }

        public void GainMaxHealth(int increaseAmount)
        {
            _currentMaxHp += increaseAmount;
            DebugHelper.LogYellow("CURRENT MAX HP : " + _currentMaxHp);
            OnMaxHealthUpdatedSendEvent();

            ControlHealth(increaseAmount);
        }

        public void CollectXp(float xpAmountToCollect)
        {
            Xp += xpAmountToCollect;

            if (Xp >= _totalRequiredXp)
            {
                Xp -= _totalRequiredXp;
                CalculateRequiredXp();
                LevelUp();
            }

            CalculateXpPercentage();
            OnXpUpdatedSendEvent();
        }


        protected override void ControlHealth(float amount)
        {
            DebugHelper.LogRed("CURRENT HEALTH : " + CurrentHealth);

            base.ControlHealth(amount);
            DebugHelper.LogRed("CURRENT HEALTH : " + CurrentHealth);

            OnHealthUpdatedSendEvent();
        }

        protected override void OnDied(float takenDamage)
        {
            base.OnDied(takenDamage);
            DebugHelper.LogRed("PLAYER IS DEAD");
        }


        private void CalculateXpPercentage()
        {
            _xpPercentage = Xp / _totalRequiredXp;
        }

        private void CalculateRequiredXp()
        {
            _totalRequiredXp = _playerStatsDataSo.playerStatsData.requiredXpForLevel.GetStatWithLevel(Level);
        }

        private void LevelUp()
        {
            Level++;
            OnLevelUpdatedSendEvent();
        }

        private void OnLevelUpdatedSendEvent()
        {
            PlayerStatsActionManager.onLevelChanged?.Invoke(Level);
        }

        private void OnHealthUpdatedSendEvent()
        {
            PlayerStatsActionManager.onHealthValueUpdated?.Invoke(CurrentHealth, healthPercentage);
        }

        private void OnMaxHealthUpdatedSendEvent()
        {
            PlayerStatsActionManager.onMaxHpValueUpdated?.Invoke(_currentMaxHp);
        }

        private void OnXpUpdatedSendEvent()
        {
            PlayerStatsActionManager.onXpValueChange?.Invoke(Xp, _xpPercentage);
        }
    }
}