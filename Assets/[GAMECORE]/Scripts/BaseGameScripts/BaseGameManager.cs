using Scripts.BaseGameScripts.GameStateManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.SceneLoadingManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts
{
    public class BaseGameManager : SingletonMono<BaseGameManager>
    {
        public GameStateManager GameStateManager => gameStateManager;
        public Camera LoaderCamera => loaderCamera;


        [SerializeField]
        private GameStateManager gameStateManager;
        
        [SerializeField]
        private Camera loaderCamera;

        protected override void OnAwake()
        {
        }

        
        private void OnEnable()
        {
            LoadSceneActionManager.onLoadingSceneStarted += OnLoadingSceneStarted;
            LoadSceneActionManager.onLoadingSceneCompleted += OnLoadingSceneCompleted;
        }
        private void OnDisable()
        {
            LoadSceneActionManager.onLoadingSceneStarted -= OnLoadingSceneStarted;
            LoadSceneActionManager.onLoadingSceneCompleted -= OnLoadingSceneCompleted;
        }

        
        private void OnLoadingSceneStarted()
        {
        }
        private void OnLoadingSceneCompleted()
        {
        }
    }
}