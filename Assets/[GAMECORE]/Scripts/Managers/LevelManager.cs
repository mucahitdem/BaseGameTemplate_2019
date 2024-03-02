using DG.Tweening;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SceneLoadingManagement;
using UnityEngine.SceneManagement;

namespace Scripts.BaseGameScripts.Managers
{
    public class LevelManager : SingletonMono<LevelManager>
    {
        private int lastLoadedLevelNum;
        protected override void OnAwake()
        {
            lastLoadedLevelNum = 1;
        }


        public void LoadLevel(int levelNum)
        {
            lastLoadedLevelNum = levelNum;
            SceneLoadActionManager.loadScene?.Invoke(AllLevelsDataSo.Instance.LevelWithName("Level" + levelNum));
        }
        public void NextLevel()
        {

        }
        public void RetryLevel()
        {
            SceneLoadActionManager.reloadScene?.Invoke();
        }
    }
}