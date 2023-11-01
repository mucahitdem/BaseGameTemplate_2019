using System;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.UiManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scripts.GameScripts.SkillManagement.SkillUiManagement
{
    public class OpenSkillTree : BaseClickableImage
    {
        private SkillUpgradePanel _skillUpgradePanel;

        [SerializeField]
        private int index;

        [SerializeField]
        private Image skillIcon;

        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            _skillUpgradePanel = (SkillUpgradePanel) baseComponent;
            var skillSprite = _skillUpgradePanel.SelectedSkills[index].skillTreeData.GetCurrentSkillToUpgrade()
                .baseSkillData;
            if (!skillSprite.skillIcon)
                DebugHelper.LogRed("SKILL " + skillSprite.skillName + " SPRITE IS NULL");
            skillIcon.sprite = skillSprite.skillIcon;
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }


        public override void OnPointerClick(PointerEventData eventData)
        {
            _skillUpgradePanel.OnSelectedSkillTree(index);
        }
    }
}