using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;

namespace Scripts.GameScripts._MainScene.BattleUiManagement
{
    public class BattleUiManager : BaseUiItem
    {
        protected override string GetUiId()
        {
            return Defs.UI_KEY_BATTLE_MANAGER;
        }
    }
}