using Scripts.BaseGameScripts.SaveAndLoadManagement;
using Scripts.GameScripts.DevHelperTools.SoCreator;
using Scripts.GameScripts.SkillManagement.SkillTreeManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.SkillManagement.SkillTreeManagement
{
    [CreateAssetMenu(fileName = "BaseSkillTree", menuName = "Game/SkillTree/BaseSkillTree", order = 0)]
    [InlineEditor]
    public class BaseSkillTreeDataSo : BaseScriptableObject, ISaveAndLoad
    {
        public BaseSkillTreeData skillTreeData;

        public void Save()
        {
            PlayerPrefs.SetInt(skillTreeData.saveKey, skillTreeData.upgradeCount);
        }

        public void Load()
        {
            skillTreeData.upgradeCount = PlayerPrefs.GetInt(skillTreeData.saveKey, 0);
        }
    }
}