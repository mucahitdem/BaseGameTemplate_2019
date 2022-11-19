using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core;

public class GameManager : Patterns_SingletonMono<GameManager>
{

    [HideInInspector] public int fakeLevelNum = 1; // ekranda gözüken (yani fake olmasınn nedeni aslında aynı levellerin dönmesi ama yeni elvelmiş gibi gösterilmesi)
    [HideInInspector] public int levelNum = 1; // gerçek level sayımız index e göre


    protected override void UseThisInsteadOfAwake() // => AWAKE
    {
        ///
    }

    private void Start()
    {
        UpdatePlayerPerfs();
    }

    void UpdatePlayerPerfs() // initial uı adjust
    {
        fakeLevelNum = PlayerPrefs.GetInt("FakeLevel",1);
        levelNum = PlayerPrefs.GetInt("Level", 1);

        UIManager.instance.UpdateLevelText();
    }

    public void SendLevelStartedEvent()
    {
        //Elephant.LevelStarted(fakeLevelNum);
    }

    public void EndGame(int endType) // 2 success // 1 fail // call this after level ended 
    {
  
        switch (endType)
        {
            case 2:
                UIManager.instance.OpenClosePanels(2);
                //Elephant.LevelCompleted(fakeLevelNum); // düzenlenecek
                break;
            case 1:
                UIManager.instance.OpenClosePanels(1);
                //Elephant.LevelFailed(fakeLevelNum); // düzenlenecek
                break;
        }
    }

    public void NextLevel() // button method
    {
        fakeLevelNum++;
        levelNum++;

        RecordLevel();
        RecordFakeLevel();

        if (levelNum == SceneManager.sceneCountInBuildSettings)
        {
            levelNum = 1;
            RecordLevel();
        }

        SceneManager.LoadScene(levelNum);
    }

    public void RetryLevel() // button method
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void RecordLevel()
    {
        PlayerPrefs.SetInt("Level", levelNum);
    }

    void RecordFakeLevel()
    {
        PlayerPrefs.SetInt("FakeLevel", fakeLevelNum);
    }

   
}
