using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addText : MonoBehaviour {
    public float x=0.5f, y=2.7f, z=-8.0f;
    public int s = 40;
    public Text text;

    TextMesh t;
	// Use this for initialization
	void Start () {
       /* GameObject text = new GameObject();
        t = text.AddComponent<TextMesh>();
        t.text = "";
        t.fontSize = s;
        t.transform.localEulerAngles = new Vector3(0, 0, 0);
        t.transform.localPosition = new Vector3(x, y,z);
        t.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        t.anchor = TextAnchor.MiddleCenter;*/
        //Instantiate(t);
    }
	
	// Update is called once per frame
	void Update () {
        //t.transform.localEulerAngles = new Vector3(0, 0, 0);
        //t.transform.localPosition = new Vector3(x, y, z);
        //t.fontSize = s;

           // text.text = GameHandler.textSet;

        
    }
}
