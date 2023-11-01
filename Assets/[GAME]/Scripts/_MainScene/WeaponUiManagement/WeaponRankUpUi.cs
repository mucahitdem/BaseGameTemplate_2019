using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.UiManagement;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts._MainScene.WeaponUiManagement
{
    public class WeaponRankUpUi : BaseClickableImage
    {
        private WeaponRankUpPanel _weaponRankUpPanel;

        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            _weaponRankUpPanel = (WeaponRankUpPanel) baseComponent;
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            _weaponRankUpPanel.RankUp();
            //DebugHelper.LogRed("CLICKED RANK UP BUTTON");
        }
    }
}