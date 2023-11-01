using System;
using Scripts.GameScripts._MainScene._GeneralUi;
using Scripts.GameScripts.WeaponManagement.Weapons;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement.OpenUis
{
    public class OpenWeaponSpecsUi : OpenUi
    {
        private BaseWeaponDataSo _weaponDataSo;

        public override void OnPointerClick(PointerEventData eventData)
        {
            WeaponUiActionManager.onClickedWeaponStatUi?.Invoke(_weaponDataSo);
        }

        protected override string UiItemToOpen()
        {
            return null;
        }

        public void InsertData(BaseWeaponDataSo weaponDataSo)
        {
            _weaponDataSo = weaponDataSo;
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }
    }
}