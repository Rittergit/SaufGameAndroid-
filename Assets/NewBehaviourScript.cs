using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public void rnd()
    {
        double x = Random.value;
        double y = Random.value;

        int k = Mathf.RoundToInt((float)x * 7);
        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(k);
    }
}
