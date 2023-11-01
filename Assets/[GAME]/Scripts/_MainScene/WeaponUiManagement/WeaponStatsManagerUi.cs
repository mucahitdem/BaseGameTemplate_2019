using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.GameScripts._MainScene.WeaponUiManagement.OpenUis;
using Scripts.GameScripts.WeaponManagement.Weapons;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement
{
    public class WeaponStatsManagerUi : BaseUiItem
    {
        [SerializeField]
        private GameObject equippedImage;

        [SerializeField]
        private OpenWeaponRankUpPanel openWeaponRankUpPanel;

        [SerializeField]
        private OpenWeaponSpecsUi openWeaponSpecsUi;

        [SerializeField]
        private BaseWeaponDataSo weaponDataSo;

        [SerializeField]
        private Image weaponImage;

        [SerializeField]
        private WeaponLevelUpgradeUi weaponLevelUpgradeUi;

        [SerializeField]
        private TextMeshProUGUI weaponName;

        protected override void OnEnable()
        {
            base.OnEnable();
            UpdateUi();
        }

        private void Start()
        {
            OnEquippedWeaponUpdated(WeaponUiActionManager.getEquippedWeapon.Invoke());
        }

        public void OnEquippedWeaponUpdated(BaseWeaponDataSo weaponEquipped)
        {
            equippedImage.SetActive(weaponEquipped.baseWeaponData.weaponName == weaponDataSo.baseWeaponData.weaponName);
        }


        protected override string GetUiId()
        {
            return Defs.UI_KEY_WEAPON_STATS_MANAGER;
        }

        [Button]
        private void UpdateUi()
        {
            var data = weaponDataSo.baseWeaponData;
            data.Load();

            weaponName.text = data.weaponName;
            weaponImage.sprite = data.weaponIcon;

            openWeaponSpecsUi.InsertData(weaponDataSo);
            openWeaponRankUpPanel.InsertData(weaponDataSo);
            weaponLevelUpgradeUi.InsertData(weaponDataSo);
        }
    }
}