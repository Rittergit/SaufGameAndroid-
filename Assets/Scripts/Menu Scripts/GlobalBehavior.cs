using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GlobalBehavior : MonoBehaviour {

    public string name;

    public void InitializeList()
    {
        int pCount = 0;
        GameObject[] inputFields = GameObject.FindGameObjectsWithTag("Input");

        foreach(GameObject inp in inputFields)
        {
            InputField actualObject = inp.GetComponent<InputField>();
            if (!(actualObject.text == ""))
            {
                pCount++;
            }
        }

        string[] plist = new string[pCount];

        int helper = 0;
        for (int i = 0; i < inputFields.Length; i++)
        {
            InputField actualObject = inputFields[i].GetComponent<InputField>();
            if (!(actualObject.text == ""))
            {
                plist[i-helper] = actualObject.text;
            }
            else
            {
                helper++;
            }
        }
        PlayerList.initList(plist);

        foreach(string s in plist)
        {
            Debug.Log(s);
        }
    }

    public void LoadScene()
    {
        InitializeList();
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
