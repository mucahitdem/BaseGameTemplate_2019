using System;
using Scripts.BaseGameScripts.UiManagement;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts._MainScene._GeneralUi
{
    public abstract class CloseUi : BaseClickableImage
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            UiActionManager.hideUiItem?.Invoke(UiItemIdToClose(), null);
        }

        protected abstract string UiItemIdToClose();

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }
    }
}