using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.UiManagement;
using Scripts.GameScripts._MainScene._GeneralUi;
using Scripts.GameScripts.WeaponManagement.Weapons;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement
{
    public class EquipButton : BaseClickableImage
    {
        private BaseWeaponDataSo _weaponDataSo;
        private WeaponSpecsUi _weaponSpecsUi;

        [SerializeField]
        private CloseUi closeUi;

        [SerializeField]
        private TextMeshProUGUI equipText;

        public override void OnPointerClick(PointerEventData eventData)
        {
            //SaveGame.Save(Defs.SAVE_KEY_EQUIPPED_WEAPON, _weaponDataSo);
            WeaponUiActionManager.onWeaponEquipped?.Invoke(_weaponDataSo);
            UpdateText("Equipped");
            closeUi.OnPointerClick(default);
        }

        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            _weaponSpecsUi = (WeaponSpecsUi) baseComponent;
            _weaponDataSo = _weaponSpecsUi.BaseWeaponDataSo;

            UpdateText(IsEquippedWeapon() ? "Equipped" : "Equip");
        }

        private void UpdateText(string targetText)
        {
            equipText.text = targetText;
        }

        private bool IsEquippedWeapon()
        {
            var equippedWeapon =
                WeaponUiActionManager.getEquippedWeapon
                    .Invoke(); //SaveGame.Load(Defs.SAVE_KEY_EQUIPPED_WEAPON, AllWeaponsDataSo.Instance.AllWeapons[0]);
            return equippedWeapon.baseWeaponData.weaponName == _weaponDataSo.baseWeaponData.weaponName;
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }
    }
}