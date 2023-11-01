using System.Globalization;
using Scripts.BaseGameScripts.UiManagement;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.GameScripts.SourceManagement;
using Scripts.GameScripts.WeaponManagement.Weapons;
using Scripts.WeaponManagement.Weapons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement
{
    public class WeaponRankUpPanel : BaseUiItem
    {
        private BaseWeaponData _weaponData;

        private BaseWeaponDataSo _weaponDataSo;

        [SerializeField]
        private TextMeshProUGUI currentAttackDamage;

        [SerializeField]
        private TextMeshProUGUI currentDividedNeededChipAmount;

        [SerializeField]
        private TextMeshProUGUI currentMaxLevel;

        [SerializeField]
        private Image currentWeaponImage;

        [SerializeField]
        private TextMeshProUGUI currentWeaponName;

        [SerializeField]
        private Image currentWeaponRankUi;

        [SerializeField]
        private TextMeshProUGUI nextAttackDamage;

        [SerializeField]
        private TextMeshProUGUI nextMaxLevel;

        [SerializeField]
        private Image nextWeaponImage;

        [SerializeField]
        private TextMeshProUGUI nextWeaponName;

        [SerializeField]
        private Image nextWeaponRankUi;

        [SerializeField]
        private WeaponRankUpUi weaponRankUpUi;

        public override void ShowUi(Object component)
        {
            base.ShowUi(component);
            _weaponDataSo = (BaseWeaponDataSo) component;
            _weaponData = _weaponDataSo.baseWeaponData;
            weaponRankUpUi.Insert(this);
            UpdateUi();
        }

        public void RankUp()
        {
            if (SourceActionManager.trySpendSource.Invoke(_weaponData.GetNextRankUpPrice(),
                _weaponData.GetRankUpgradeSourceType()))
            {
                _weaponData.UpgradeWeaponRank();
                UiActionManager.hideUiItem.Invoke(uiItemId, null);
                UiActionManager.showUiItem.Invoke(Defs.UI_KEY_WEAPON_RANK_UP_SUCCESSFUL_PANEL, null);
                WeaponUiActionManager.onWeaponRankUpgraded?.Invoke(_weaponDataSo);
            }
        }

        private void UpdateUi()
        {
            var data = _weaponDataSo.baseWeaponData;
            currentWeaponName.text = data.weaponName;
            nextWeaponName.text = data.weaponName;

            currentWeaponImage.sprite = data.weaponIcon;
            nextWeaponImage.sprite = data.weaponIcon;

            currentMaxLevel.text = data.GetCurrentRankUpMaxLevel().ToString();
            nextMaxLevel.text = data.GetNextRankUpMaxLevel().ToString();

            currentAttackDamage.text = data.GetCurrentAttackDamage().ToString(CultureInfo.InvariantCulture);
            nextAttackDamage.text = data.GetNextAttackDamageOnRankUp().ToString(CultureInfo.InvariantCulture);

            var currentSourceCount = SourceActionManager.getCurrentSource.Invoke(data.GetLevelUpgradeSourceType());
            currentDividedNeededChipAmount.text = currentSourceCount + "/" + data.GetNextRankUpPrice();
        }

        protected override string GetUiId()
        {
            return Defs.UI_KEY_WEAPON_RANK_UP_PANEL;
        }
    }
}