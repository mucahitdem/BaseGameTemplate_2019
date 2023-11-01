using System;
using System.Collections;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using Scripts.WeaponManagement.Weapons;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.WeaponManagement.Weapons
{
    public class WeaponUi : BaseUiItem
    {
        private PlayerManager _playerManager;


        private BaseWeapon _weapon;

        [FoldoutGroup("Ammo")]
        [SerializeField]
        private Transform ammoCanvas;

        [FoldoutGroup("Ammo")]
        [SerializeField]
        private TextMeshProUGUI ammoCount;

        [FoldoutGroup("Ammo")]
        [SerializeField]
        private Vector3 offset;

        [FoldoutGroup("Reload")]
        [SerializeField]
        private Image reloadFillBar;

        [FoldoutGroup("Range")]
        [SerializeField]
        private WeaponRangeUi weaponRangeUi;

        private PlayerManager PlayerManager
        {
            get
            {
                if (!_playerManager)
                    _playerManager = GameManager.Instance.Player;

                return _playerManager;
            }
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(.1f);
            SetRange(PlayerManager.Weapon.CurrentFireRange);
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            // WeaponActionManager.onAmmoCountUpdated += SetAmmo;
            // WeaponActionManager.onFireRangeUpdated += SetRange;
            // WeaponActionManager.onReloadTimerUpdate += OnReloadTimerUpdate;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            // WeaponActionManager.onAmmoCountUpdated -= SetAmmo;
            // WeaponActionManager.onFireRangeUpdated -= SetRange;
            // WeaponActionManager.onReloadTimerUpdate -= OnReloadTimerUpdate;
        }

        private void Update()
        {
            if (!PlayerManager)
                return;
            ammoCanvas.position = PlayerManager.TransformOfObj.position + offset;
        }

        private void OnReloadTimerUpdate(float passedDurationRate)
        {
            if (reloadFillBar)
                reloadFillBar.fillAmount = passedDurationRate;
        }

        private void SetAmmo(int ammo)
        {
            ammoCount.text = ammo.ToString();
        }

        private void SetRange(float fireRange)
        {
            weaponRangeUi.UpdateRange(fireRange);
        }
    }
}