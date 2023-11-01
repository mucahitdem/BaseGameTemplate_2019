using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts._AllDataSo;
using Scripts.GameScripts.SkillManagement.SkillTreeManagement;
using Scripts.SkillManagement.SkillTreeManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.SkillManagement
{
    public class SkillTreeSelector : BaseComponent
    {
        private readonly List<BaseSkillTreeDataSo> _availableSkills = new List<BaseSkillTreeDataSo>();

        [SerializeField]
        [ReadOnly]
        private List<BaseSkillTree> upgradedSkills = new List<BaseSkillTree>();

        public BaseSkillTreeDataSo[] GetRandomSkill()
        {
            _availableSkills.Clear();
            var skills = new BaseSkillTreeDataSo[3];
            var allSkills = AllSkillTreeDataSo.Instance.AllSkillTrees;
            for (var i = 0; i < allSkills.Length; i++)
            {
                if (allSkills[i].skillTreeData.upgradeCount >= allSkills[i].skillTreeData.skills.Length)
                    continue;
                _availableSkills.Add(allSkills[i]);
            }

            for (var i = 0; i < skills.Length; i++)
            {
                var randomSkill = _availableSkills[Random.Range(0, _availableSkills.Count)];
                skills[i] = randomSkill;
                _availableSkills.Remove(randomSkill);
            }

            return skills;
        }
    }
}