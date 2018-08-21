using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenSettings : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // Screen.SetResolution(1080,1920, false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            //Screen.SetResolution(1080, 1920, false);
            // Screen.orientation = ScreenOrientation.Landscape;
        }
        else Screen.orientation = ScreenOrientation.Portrait;
    }
}
