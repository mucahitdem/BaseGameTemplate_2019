using System;
using Scripts.GameScripts._MainScene._GeneralUi;
using Scripts.GameScripts.WeaponManagement.Weapons;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement.OpenUis
{
    public class OpenWeaponRankUpPanel : OpenUi
    {
        private BaseWeaponDataSo _weaponDataSo;

        public override void OnPointerClick(PointerEventData eventData)
        {
            WeaponUiActionManager.onClickedOpenRankUpButton?.Invoke(_weaponDataSo);
        }

        protected override string UiItemToOpen()
        {
            throw new NotImplementedException();
        }

        public void InsertData(BaseWeaponDataSo baseWeaponDataSo)
        {
            _weaponDataSo = baseWeaponDataSo;
        }

        protected override string GetUiId()
        {
            return "";
        }
    }
}