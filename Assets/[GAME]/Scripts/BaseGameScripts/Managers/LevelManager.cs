﻿using BayatGames.SaveGameFree;
using Scripts.BaseGameScripts.SaveAndLoad;
using Scripts.BaseGameScripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.BaseGameScripts.Managers
{
    public class LevelManager : MonoBehaviour, ISaveAndLoad
    {
        [Title("Private Variables")]
        private int _fakeLevelNum = 1;

        private int _levelNum = 1;

        [Title("Managers")]
        private UiManager _uiManager;

        public void Save()
        {
            SaveGame.Save("Level", _levelNum); // replace
            SaveGame.Save("FakeLevel", _fakeLevelNum); // replace
        }

        public void Load()
        {
            _levelNum = SaveGame.Load("Level", 0);
            _fakeLevelNum = SaveGame.Load("FakeLevel", _fakeLevelNum);
        }

        private void Awake()
        {
            Load();
        }

        private void Start()
        {
            _uiManager = GlobalReferences.Instance.uiManager;
        }

        public void NextLevel()
        {
            _fakeLevelNum++;
            _levelNum++;

            if (_levelNum == SceneManager.sceneCountInBuildSettings) // loop
                _levelNum = 1;

            Save();

            SceneManager.LoadScene(_levelNum);
        }

        public void RetryLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}