using System;
using System.Globalization;
using Scripts.BaseGameScripts.UiManagement;
using Scripts.GameScripts.SourceManagement;
using Scripts.GameScripts.WeaponManagement.Weapons;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement
{
    public class WeaponLevelUpgradeUi : BaseClickableImage
    {
        private BaseWeaponDataSo _weaponDataSo;

        [SerializeField]
        private TextMeshProUGUI attackDamageText;

        [SerializeField]
        private TextMeshProUGUI levelText;

        [SerializeField]
        private TextMeshProUGUI priceText;


        public override void OnPointerClick(PointerEventData eventData)
        {
            if (SourceActionManager.trySpendSource(_weaponDataSo.baseWeaponData.GetLevelUpgradePrice(),
                _weaponDataSo.baseWeaponData.weaponLevelUpgradeData.sourceType))
            {
                _weaponDataSo.baseWeaponData.UpgradeWeaponLevel();
                UpdateUi();
                WeaponUiActionManager.onWeaponLevelUpgraded?.Invoke(_weaponDataSo);
            }
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            WeaponUiActionManager.updateAllUi += UpdateUi;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            WeaponUiActionManager.updateAllUi -= UpdateUi;
        }

        public void InsertData(BaseWeaponDataSo weaponDataSo)
        {
            _weaponDataSo = weaponDataSo;
            UpdateUi();
        }

        private void UpdateUi()
        {
            var data = _weaponDataSo.baseWeaponData;
            data.Load();

            //DebugHelper.LogRed("CURRENT LEVEL : " + data.GetCurrentWeaponLevel().ToString());
            levelText.text = data.GetCurrentWeaponLevel() + "/" + data.GetCurrentRankUpMaxLevel();
            priceText.text = data.GetLevelUpgradePrice().ToString();
            attackDamageText.text = data.GetCurrentAttackDamage().ToString(CultureInfo.InvariantCulture);
        }


        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }
    }
}