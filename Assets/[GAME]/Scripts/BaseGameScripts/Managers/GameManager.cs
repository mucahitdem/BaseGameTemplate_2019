using Scripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Title("Managers")]
        private UiManager _uiManager;
    
        [Title("Private Variables")]
        private int _fakeLevelNum = 1; 
        private int _levelNum = 1; 
  
        private void Start()
        {
            _uiManager = GlobalReferences.Instance.uiManager;
            UpdatePlayerPrefs();
        }

        void UpdatePlayerPrefs() // initial uı adjust
        {
            _fakeLevelNum = PlayerPrefs.GetInt("FakeLevel",1);
            _levelNum = PlayerPrefs.GetInt("Level", 1);
        }
        

        public void NextLevel() // button method
        {
            _fakeLevelNum++;
            _levelNum++;

            RecordLevel();
            RecordFakeLevel();

            if (_levelNum == SceneManager.sceneCountInBuildSettings)
            {
                _levelNum = 1;
                RecordLevel();
            }

            SceneManager.LoadScene(_levelNum);
        }

        public void RetryLevel() // button method
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
        void RecordLevel()
        {
            PlayerPrefs.SetInt("Level", _levelNum);
        }

        void RecordFakeLevel()
        {
            PlayerPrefs.SetInt("FakeLevel", _fakeLevelNum);
        }

 
    }
}
