using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.GameScripts.SkillManagement.SkillTreeManagement;
using Scripts.SkillManagement.SkillTreeManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement.SkillUiManagement
{
    public class SkillUpgradePanel : BaseUiItem
    {
        private int _currentIndex;

        [SerializeField]
        private OpenSkillTree[] openSkillTrees;

        [SerializeField]
        private SkillDataUi skillDataUi;

        [SerializeField]
        private SkillUpgradeButton skillUpgradeButton;

        public BaseSkillTreeDataSo[] SelectedSkills { get; private set; }

        private void Awake()
        {
            _currentIndex = 0;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            SkillActionManager.onSkillsSelected += InsertSelectedSkills;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            SkillActionManager.onSkillsSelected -= InsertSelectedSkills;
        }

        public void UpgradeSkill()
        {
            SkillActionManager.upgradeSkill?.Invoke(SelectedSkills[_currentIndex]);
            // _currentSkills[_currentIndex].skillTreeData.GetCurrentSkillToUpgrade().baseSkill.UseSkill();
            // _currentSkills[_currentIndex].skillTreeData.upgradeCount++;
            Time.timeScale = 1f;
            Go.SetActive(false);
        }


        private void InsertSelectedSkills(BaseSkillTreeDataSo[] selectedSkills)
        {
            _currentIndex = 0;
            SelectedSkills = selectedSkills;
            InsertData();
            skillDataUi.OnSelectedSkillTree(SelectedSkills[_currentIndex]);
            Go.SetActive(true);
        }

        public void OnSelectedSkillTree(int index)
        {
            _currentIndex = index;
            skillDataUi.OnSelectedSkillTree(SelectedSkills[_currentIndex]);
        }

        protected override string GetUiId()
        {
            return Defs.UI_KEY_SKILL_UPGRADE_PANEL;
        }

        private void InsertData()
        {
            skillUpgradeButton.Insert(this);
            for (var i = 0; i < openSkillTrees.Length; i++)
            {
                var openSkillTree = openSkillTrees[i];
                openSkillTree.Insert(this);
            }
        }
    }
}