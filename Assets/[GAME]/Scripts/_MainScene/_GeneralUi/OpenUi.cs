using Scripts.BaseGameScripts.UiManagement;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts._MainScene._GeneralUi
{
    public abstract class OpenUi : BaseClickableImage
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            UiActionManager.showUiItem?.Invoke(UiItemToOpen(), null);
        }

        protected abstract string UiItemToOpen();
    }
}