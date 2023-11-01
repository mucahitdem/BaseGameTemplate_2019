using Scripts._NewData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME_.Scripts.GameScripts._NewData
{
    [CreateAssetMenu(fileName = "AllCharData", menuName = "Game/Data/AllCharData", order = 0)]
    public class AllCharData : ScriptableObject
    {
        public CharacterData[] allCharData;

        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllCharData s_instance;

        public static AllCharData Instance => s_instance ??= Resources.Load<AllCharData>("AllCharData");

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("AllCharData is missing in the resources folder.");
        }

        #endregion
    }
}