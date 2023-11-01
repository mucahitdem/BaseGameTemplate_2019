using System;
using Scripts.BaseGameScripts.SceneLoadingManagement;
using Scripts.BaseGameScripts.UiManagement;
using Scripts.GameScripts.SceneLoadingManagement;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts.LevelEndManagement
{
    public class GoToMainLevelButton : BaseClickableImage
    {
        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            LoadSceneActionManager.loadScene?.Invoke(
                AllLevelsDataSo.Instance.GetSceneToLoad(Defs.SCENE_NAME_LEVEL_MAIN));
        }
    }
}