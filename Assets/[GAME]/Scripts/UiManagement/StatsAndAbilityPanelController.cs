using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.StatsManagement.PlayerStatsManagement;
using Scripts.PlayerManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.UiManagement
{
    public class StatsAndAbilityPanelController : BaseComponent
    {
        private PlayerManager _playerManager;

        [SerializeField]
        private TextMeshProUGUI levelText;

        [SerializeField]
        private Image xpFillBar;


        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            PlayerStatsActionManager.onXpValueChange += OnXpValueChanged;
            PlayerStatsActionManager.onLevelChanged += OnLevelChanged;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            PlayerStatsActionManager.onXpValueChange -= OnXpValueChanged;
            PlayerStatsActionManager.onLevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(int level)
        {
            levelText.text = level.ToString();
        }

        private void OnXpValueChanged(float xpValue, float xpPercentage)
        {
            xpFillBar.fillAmount = xpPercentage;
        }
    }
}