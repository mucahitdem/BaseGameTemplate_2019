using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scripts.GameScripts.SceneLoadingManagement
{
    [Serializable]
    public class SceneSerialization
    {
        [SerializeField]
        private bool isActiveScene;

        [SerializeField]
        private bool neverUnloadScene;


        [SerializeField]
        private Object scene;

        public string sceneName;
        public bool IsActiveScene => isActiveScene;
        public bool NeverUnloadScene => neverUnloadScene;
        public Object Scene => scene;

        [Button]
        private void GetName()
        {
            sceneName = scene.name;
        }
    }
}