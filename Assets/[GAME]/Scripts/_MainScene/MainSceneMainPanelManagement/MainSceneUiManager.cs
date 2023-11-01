using Scripts._MainScene.WeaponUiManagement;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.UiManagement;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.GameScripts._MainScene.BattleUiManagement;
using Scripts.GameScripts._MainScene.ShopUiManagement;
using Scripts.GameScripts._MainScene.WeaponUiManagement;
using UnityEngine;

namespace Scripts.GameScripts._MainScene.MainSceneMainPanelManagement
{
    public class MainSceneUiManager : BaseComponent
    {
        private BaseUiItem[] _screens;

        [SerializeField]
        private BattleUiManager battleUiManager;

        [SerializeField]
        private ShopUiManager shopUiManager;

        [SerializeField]
        private WeaponUiManager weaponUiManager;

        private void Awake()
        {
            _screens = new BaseUiItem[3];
            _screens[0] = shopUiManager;
            _screens[1] = battleUiManager;
            _screens[2] = weaponUiManager;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            MainSceneUiActionManager.enableUiManager += EnableUiManager;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            MainSceneUiActionManager.enableUiManager -= EnableUiManager;
        }


        private void EnableUiManager(string uiManagerToEnable)
        {
            for (var i = 0; i < _screens.Length; i++)
            {
                var currentScreen = _screens[i];
                if (currentScreen.UiItemId == uiManagerToEnable)
                    UiActionManager.showUiItem?.Invoke(currentScreen.UiItemId, null);
                else
                    UiActionManager.hideUiItem?.Invoke(currentScreen.UiItemId, null);
            }
        }
    }
}