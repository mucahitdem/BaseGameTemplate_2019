﻿using Scripts.GameScripts._MainScene._GeneralUi;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts._MainScene.MainSceneMainPanelManagement
{
    public class WeaponButtonMainPanel : OpenUi
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            MainSceneUiActionManager.enableUiManager?.Invoke(UiItemToOpen());
        }


        protected override string GetUiId()
        {
            return "";
        }

        protected override string UiItemToOpen()
        {
            return Defs.UI_KEY_WEAPON_MANAGER;
        }
    }
}