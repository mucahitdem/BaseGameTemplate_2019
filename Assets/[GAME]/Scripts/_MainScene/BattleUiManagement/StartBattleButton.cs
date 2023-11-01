using System;
using Scripts.BaseGameScripts.SceneLoadingManagement;
using Scripts.BaseGameScripts.UiManagement;
using Scripts.GameScripts.SceneLoadingManagement;
using UnityEngine.EventSystems;

namespace Scripts._MainScene.BattleUiManagement
{
    public class StartBattleButton : BaseClickableImage
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            LoadSceneActionManager.loadScene?.Invoke(AllLevelsDataSo.Instance.GetSceneToLoad(Defs.SCENE_NAME_LEVEL_1));
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }
    }
}