using Scripts.GameScripts.DevHelperTools.SoCreator;
using Scripts.GameScripts.SkillManagement.SkillTreeManagement;
using Scripts.SkillManagement.SkillTreeManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts._AllDataSo
{
    [CreateAssetMenu(fileName = "AllSkillTreeData", menuName = "Game/Data/AllSkillTreeData", order = 0)]
    public class AllSkillTreeDataSo : BaseScriptableObject
    {
        [SerializeField]
        private BaseSkillTreeDataSo[] allSkillTrees;


        public BaseSkillTreeDataSo[] AllSkillTrees => allSkillTrees;

        public void ResetAllData()
        {
            for (var i = 0; i < allSkillTrees.Length; i++)
            {
                var currentSkillTree = allSkillTrees[i];
                currentSkillTree.skillTreeData.upgradeCount = 0;
            }
        }

        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllSkillTreeDataSo s_instance;

        public static AllSkillTreeDataSo Instance =>
            s_instance ??= Resources.Load<AllSkillTreeDataSo>("AllSkillTreeData");

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("AllSkillTreeData asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
    }
}