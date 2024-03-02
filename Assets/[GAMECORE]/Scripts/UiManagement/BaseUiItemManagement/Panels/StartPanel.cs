using Scripts.BaseGameScripts.GameStateManagement.States;
using Scripts.GameStateManagement.States;
using UnityEngine.EventSystems;

namespace Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement.Panels
{
    public class StartPanel : BaseUiPanel, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            BaseGameManager.Instance.GameStateManager.SetState(new GamePlayState());
        }
    }
}