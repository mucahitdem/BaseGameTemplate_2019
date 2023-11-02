using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts
{
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static T s_instance;

        private static string s_nameOfDataSo;

        public static T Instance
        {
            get
            {
                if (!s_instance) s_instance = Resources.Load<T>(s_nameOfDataSo);

                return s_instance;
            }
        }

        protected static void SetNameOfDataSo(string nameOfData)
        {
            s_nameOfDataSo = nameOfData;
        }

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("Instance of type is missing in the resources folder.");
        }
    }
}