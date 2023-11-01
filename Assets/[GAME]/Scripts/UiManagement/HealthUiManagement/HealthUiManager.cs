using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.UiManagement.HealthUiManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.StatsManagement.PlayerStatsManagement
{
    public class HealthUiManager : BaseComponent
    {
        private int _health;

        [SerializeField]
        private HealthIconController[] healthIconControllers;

        [Button]
        private void GetHeartIcons()
        {
            healthIconControllers = GetComponentsInChildren<HealthIconController>(true);
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            PlayerStatsActionManager.onHealthValueUpdated += OnHealthValueChanged;
            PlayerStatsActionManager.onMaxHpValueUpdated += OnMaxHpValueUpdated;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            PlayerStatsActionManager.onHealthValueUpdated -= OnHealthValueChanged;
            PlayerStatsActionManager.onMaxHpValueUpdated -= OnMaxHpValueUpdated;
        }


        private void OnHealthValueChanged(float healthValue, float healthPercentage)
        {
            _health = (int) healthValue;
            UpdateHealthUi();
        }

        private void UpdateHealthUi()
        {
            for (var i = _health; i >= 0; i--)
            {
                var isActive = i < _health;
                healthIconControllers[i].ControlIcon(isActive);
            }
        }

        private void OnMaxHpValueUpdated(int maxHealth)
        {
            for (var i = 0; i < maxHealth; i++)
                healthIconControllers[i].ActivateHeart();
        }
    }
}