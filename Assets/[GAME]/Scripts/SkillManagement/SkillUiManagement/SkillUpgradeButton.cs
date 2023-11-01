using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.UiManagement;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts.SkillManagement.SkillUiManagement
{
    public class SkillUpgradeButton : BaseClickableImage
    {
        private SkillUpgradePanel _skillUpgradePanel;

        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            _skillUpgradePanel = (SkillUpgradePanel) baseComponent;
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            _skillUpgradePanel.UpgradeSkill();
        }
    }
}