using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.UiManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Scripts.GameScripts.SkillManagement.SkillTreeManagement;
using Scripts.PlayerManagement;
using Scripts.SkillManagement.SkillTreeManagement;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement
{
    public class SkillManager : BaseComponent
    {
        private PlayerManager _playerManager;

        [SerializeField]
        private Transform skillsParent;

        [SerializeField]
        private SkillTreeSelector skillTreeSelector; // also get with code

        public List<BaseSkill> ActivatedSkills { get; } = new List<BaseSkill>();

        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            _playerManager = (PlayerManager) baseComponent;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            SkillActionManager.upgradeSkill += OnUpgradeSkill;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            SkillActionManager.upgradeSkill -= OnUpgradeSkill;
        }

        private void OnUpgradeSkill(BaseSkillTreeDataSo newSkillTree)
        {
            var skillTreeData = newSkillTree.skillTreeData;
            var skillToUpgrade = skillTreeData.GetCurrentSkillToUpgrade().baseSkill;
            //DebugHelper.LogRed("CREATE SKILL : " + skillToUpgrade.name);

            var skillCreated = Instantiate(skillToUpgrade, skillsParent);
            skillCreated.TransformOfObj.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
            skillCreated.UseSkill();

            ActivatedSkills.Add(skillCreated);
            skillTreeData.upgradeCount++;
        }

        public void OpenSkillUpgradePanel()
        {
            var selectedSkills = skillTreeSelector.GetRandomSkill();
            UiActionManager.showUiItem?.Invoke(Defs.UI_KEY_SKILL_UPGRADE_PANEL, null);
            SkillActionManager.onSkillsSelected?.Invoke(selectedSkills);
        }

        public BaseSkill GetSkill(BaseSkill skill)
        {
            for (var i = 0; i < ActivatedSkills.Count; i++)
            {
                var currentSkill = ActivatedSkills[i];
                if (currentSkill == skill)
                    return skill;
            }

            return null;
        }
    }
}