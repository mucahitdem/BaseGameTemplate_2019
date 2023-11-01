using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillHelpersManagement
{
    public class IncreaseReloadSpeed : BaseComponent
    {
        private float _percentage;
        private PlayerManager _playerManager;
        private float _totalPercentage;

        private PlayerManager PlayerManager
        {
            get
            {
                if (!_playerManager)
                    _playerManager = GameManager.Instance.Player;
                return _playerManager;
            }
        }

        public void SetData(float percentage, ref Action<Vector3, float, FireType> increaseReloadSpeedOnActionRaised,
            ref Action decreaseReloadSpeedOnActionRaised)
        {
            _percentage = percentage;
            increaseReloadSpeedOnActionRaised += IncreaseReloadSpeedPercentage;
            decreaseReloadSpeedOnActionRaised += DecreaseReloadSpeedPercentage;
        }

        private void IncreaseReloadSpeedPercentage(Vector3 pos, float value, FireType fireType)
        {
            PlayerManager.Weapon.increaseReloadSpeedPercentage?.Invoke(_percentage);
            _totalPercentage += _percentage;
        }

        private void DecreaseReloadSpeedPercentage()
        {
            PlayerManager.Weapon.increaseReloadSpeedPercentage?.Invoke(-_totalPercentage);
            _totalPercentage = 0f;
        }
    }
}