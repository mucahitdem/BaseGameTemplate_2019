using UnityEngine;
using UnityEditor;
using System.IO;
public class MenuItems
{
    static string path;

    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void NewMenuOption() => PlayerPrefs.DeleteAll();


    [MenuItem("Tools/Pause Game _p")]
    private static void TimeScalePause() => Time.timeScale = Time.timeScale == 0 ? 1 : 0;

    [MenuItem("Tools/Slow Time _o")]
    private static void TimeScaleSlow()
    {
        Time.timeScale = Time.timeScale == .5f ? 1 : .5f;
    }
    
    [MenuItem("Tools/Fast Time _i")]
    private static void TimeScaleFast()
    {
        switch(Time.timeScale)
        {
            case 0:
                Time.timeScale = 1;
                break;
            case .5f:
                Time.timeScale = 1;
                break;
            case 1:
                Time.timeScale = 2;
                break;
            case 2:
                Time.timeScale = 5;
                break;
            case 5:
                Time.timeScale = 1;
                break;
        }
    }

    [MenuItem("Tools/Screen Shoot _s")]
    private static void ScreenShot()
    {
        PathCalculator();

        int iScrShotNo = PlayerPrefs.GetInt("iScrShotNo", 0);

        ScreenCapture.CaptureScreenshot(path + "\\s_" + iScrShotNo.ToString() + ".png");

        iScrShotNo++;

        PlayerPrefs.SetInt("iScrShotNo", iScrShotNo);
    }

    static void PathCalculator()
    {
        string size = Screen.height.ToString();

        path = Application.dataPath + "\\..\\SS\\" + size;

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }
}