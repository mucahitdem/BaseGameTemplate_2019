using Scripts.BaseGameScripts.SourceManagement;
using Scripts.GameScripts.DevHelperTools.SoCreator;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts._AllDataSo
{
    [CreateAssetMenu(fileName = "AllSourceData", menuName = "Game/Data/All Source Data", order = 0)]
    public class AllSourceDataSo : BaseScriptableObject
    {
        [SerializeField]
        private BaseSourceDataSo[] allSources;


        public BaseSourceDataSo[] AllSources => allSources;

        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllSourceDataSo s_instance;

        public static AllSourceDataSo Instance => s_instance ??= Resources.Load<AllSourceDataSo>("AllSourceData");

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("AllSourceData asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
    }
}