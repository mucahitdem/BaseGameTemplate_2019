using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrShoot : MonoBehaviour {

    // Update is called once per frame
    void Update () 
    {
		if(Input.GetKeyDown(KeyCode.S))
        {
            int iScrShotNo = PlayerPrefs.GetInt("iScrShotNo", 0);
            ScreenCapture.CaptureScreenshot("s_" + iScrShotNo.ToString() +".png");
            iScrShotNo++;
            PlayerPrefs.SetInt("iScrShotNo", iScrShotNo);
        }
			
	}
}
