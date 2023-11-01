using Scripts.GameScripts.DevHelperTools.SoCreator;
using Scripts.GameScripts.SkillManagement.AllSkills._SkillBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts._AllDataSo
{
    [CreateAssetMenu(fileName = "AllSkillData", menuName = "Game/Data/All Skill Data", order = 0)]
    public class AllSkillsDataSo : BaseScriptableObject
    {
        [SerializeField]
        private BaseSkillDataSo[] allSkills;


        public BaseSkillDataSo[] AllSkills => allSkills;

        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllSkillsDataSo s_instance;

        public static AllSkillsDataSo Instance => s_instance ??= Resources.Load<AllSkillsDataSo>("AllSkillData");

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("AllSkillData asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
    }
}