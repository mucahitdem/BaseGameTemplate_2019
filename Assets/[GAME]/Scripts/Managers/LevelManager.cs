using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadLastScene();
    }
    public static void LoadLastScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level" , 1));
    }
}
