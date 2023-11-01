using System;
using Scripts.BaseGameScripts.UiManagement;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement
{
    public class WeaponStatsUpgradeButton : BaseClickableImage
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }
    }
}