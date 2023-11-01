using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;

namespace Scripts.GameScripts._MainScene.ShopUiManagement
{
    public class ShopUiManager : BaseUiItem
    {
        protected override string GetUiId()
        {
            return uiItemId = Defs.UI_KEY_SHOP_MANAGER;
        }
    }
}