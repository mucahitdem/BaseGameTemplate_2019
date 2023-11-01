using System.Globalization;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.GameScripts.WeaponManagement.Weapons;
using Scripts.WeaponManagement.Weapons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement
{
    public class WeaponSpecsUi : BaseUiItem
    {
        [SerializeField]
        private EquipButton equipButton;

        [SerializeField]
        private TextMeshProUGUI weaponAdTx;

        [SerializeField]
        private TextMeshProUGUI weaponBulletDamageTx;

        [SerializeField]
        private TextMeshProUGUI weaponFireRateTx;

        [SerializeField]
        private Image weaponIcon;

        [SerializeField]
        private TextMeshProUGUI weaponLevelTx;

        [SerializeField]
        private TextMeshProUGUI weaponMaxAmmo;

        [SerializeField]
        private TextMeshProUGUI weaponNameTx;

        [SerializeField]
        private TextMeshProUGUI weaponProjectilesTx;

        [SerializeField]
        private Image weaponQualityIcon;

        public BaseWeaponDataSo BaseWeaponDataSo { get; private set; }

        private void Awake()
        {
            uiItemId = Defs.UI_KEY_WEAPON_SPECS;
        }

        public override void ShowUi(Object component)
        {
            base.ShowUi(component);
            BaseWeaponDataSo = (BaseWeaponDataSo) component;
            var weaponData = BaseWeaponDataSo.baseWeaponData;

            equipButton.Insert(this);

            UpdateUi(weaponData);
        }

        protected override string GetUiId()
        {
            return uiItemId = Defs.UI_KEY_WEAPON_SPECS;
        }

        private void UpdateUi(BaseWeaponData weaponData)
        {
            weaponNameTx.text = weaponData.weaponName;
            weaponIcon.sprite = weaponData.weaponIcon;

            weaponFireRateTx.text = weaponData.fireRate.ToString(CultureInfo.InvariantCulture);
            weaponBulletDamageTx.text = weaponData.bulletDamage.ToString(CultureInfo.InvariantCulture);
            weaponProjectilesTx.text = weaponData.projectiles.ToString();
            weaponMaxAmmo.text = weaponData.maxAmmo.ToString();
        }
    }
}