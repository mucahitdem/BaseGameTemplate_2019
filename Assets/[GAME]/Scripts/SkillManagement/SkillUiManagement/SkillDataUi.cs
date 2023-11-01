using System;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.GameScripts.SkillManagement.SkillTreeManagement;
using Scripts.SkillManagement.SkillTreeManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.SkillManagement.SkillUiManagement
{
    public class SkillDataUi : BaseUiItem
    {
        [SerializeField]
        private TextMeshProUGUI skillDescription;

        [SerializeField]
        private Image[] skillIcons;

        [SerializeField]
        private TextMeshProUGUI skillName;

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }

        public void OnSelectedSkillTree(BaseSkillTreeDataSo skillTreeDataSo)
        {
            var data = skillTreeDataSo.skillTreeData.GetCurrentSkillToUpgrade().baseSkillData;
            skillName.text = data.skillName;
            skillDescription.text = data.skillDescription;

            for (var i = 0; i < skillIcons.Length; i++)
            {
                var currentIcon = skillIcons[i];
                if (i >= skillTreeDataSo.skillTreeData.skills.Length)
                {
                    currentIcon.gameObject.SetActive(false);
                    return;
                }

                currentIcon.gameObject.SetActive(true);
                currentIcon.sprite = skillTreeDataSo.skillTreeData.skills[i].baseSkillData.skillIcon;
            }
        }
    }
}