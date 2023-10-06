using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using UnityEngine.EventSystems;

namespace Scripts.BaseGameScripts.UiManagement
{
    public abstract class BaseClickableImage : BaseUiItem, IPointerClickHandler
    {
        public abstract void OnPointerClick(PointerEventData eventData);
    }
}