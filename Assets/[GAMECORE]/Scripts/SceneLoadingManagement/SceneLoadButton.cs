using Scripts.BaseGameScripts.SceneLoadingManagement;
using Scripts.UiManagement.BaseUiItemManagement;
using UnityEngine;

namespace Scripts.SceneLoadingManagement
{
    public class SceneLoadButton : BaseUiButton
    {

        [SerializeField]
        private string sceneNameToLoad;
        
        private void LoadScene()
        {
            var sceneToLoad = AllLevelsDataSo.Instance.LevelWithName(sceneNameToLoad);
            SceneLoadActionManager.loadScene?.Invoke(sceneToLoad);
        }

        protected override string GetUiId()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnClick()
        {
            base.OnClick();
            LoadScene();
        }
    }
}