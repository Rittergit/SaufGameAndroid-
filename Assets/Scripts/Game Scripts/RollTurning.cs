using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTurning : MonoBehaviour {

    public float slow;
    public string ausgabe;
    public GameObject rb;
    public float rotSpeed = 0.0f;
    private Vector2 pos1,pos2;
    private float start, end;
    private bool isDragged = false;
    public int speed, count = 0;

    // Use this for initialization
    void Start () {
		rb.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.transform.Rotate(0, 0, -rotSpeed);
        if (isDragged)
        {
            rotSpeed = (pos2.y - pos1.y) * speed / ((end - start)*100);
            isDragged = false;
            count++;
        }
        
        if((rotSpeed >= -1.0f)&& (rotSpeed <= 1.0f))
        {
            rotSpeed = 0;
        }
        else
        {
            if(rotSpeed < -1.0f)
                rotSpeed+=slow;
            if (rotSpeed > 1.0f)
                rotSpeed-=slow;
        }
    }

    void OnMouseDown()
    {
        pos1 = Input.mousePosition;
        start = Time.time;
        ausgabe = "input get";
    }
    void OnMouseUp()
    {
        pos2 = Input.mousePosition;
        end = Time.time;
        isDragged = true;
        ausgabe = "input getup";
    }
}
