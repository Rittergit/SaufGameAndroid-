using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayer : MonoBehaviour {
    
    public Transform EnterName;
    public Transform parent;
    public int startPoint = 100;
    public int latestPos = 0;
    public int translation = 30;


    public void Add()
    {
        GameObject[] inputFields = GameObject.FindGameObjectsWithTag("Input");
        //InputField actualObject = inputFields[inputFields.Length - 1].GetComponent<InputField>();
        latestPos = -inputFields.Length * translation + startPoint;
        //Debug.Log(latestPos);

        Debug.Log(inputFields[inputFields.Length - 1].transform.localPosition);
        //latestPos = Mathf.RoundToInt(actualObject.transform.position.y);
        //Debug.Log(actualObject.transform.position.y);
        var input = Instantiate(EnterName, new Vector3(25,latestPos,0), Quaternion.identity);
            input.SetParent(parent, false);  
        
        
    }
    public void Delete()
    {

        latestPos +=translation;
        Debug.Log(latestPos);
        GameObject[] inputFields = GameObject.FindGameObjectsWithTag("Input");

        if (inputFields.Length > 1)
        {
            Destroy(inputFields[inputFields.Length-1]);
        }
        
        
    }
}
