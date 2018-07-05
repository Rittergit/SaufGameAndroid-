using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GlobalBehavior : MonoBehaviour {

    public string name; 

    public void LoadScene()
    {
        SceneManager.LoadScene(name);
    }

    public void ApplicationExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
