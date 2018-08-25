using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTurning : MonoBehaviour {

    public float slow=0.5f,slow2=0.2f,speed;
    public double startAngel;
    private int sides=32;
    private double[] angels;
    public string ausgabe;
    public GameObject rb;
    public float rotSpeed = 0.0f, actualRotation=0.0f;
    private Vector2 pos1,pos2;
    private float start, end;
    private bool isDragged = false;
    public int count = 0;
    private bool isRotating;
    private double endAngel=0;

    // Use this for initialization
    void Start() {
        rb.GetComponent<Rigidbody>();
        angels = new double[sides];

        for(int i=0; i<sides; i++)
        {
            angels[i] = startAngel + (double)360 / (double)sides * (double)i;
            Debug.Log(angels[i]);
        }

	}
	
	// Update is called once per frame
	void Update () {

        actualRotation = rb.transform.eulerAngles.z;


        //rb.transform.rotation= new Quaternion(rb.transform.localRotation.x, rb.transform.localRotation.y, rb.transform.localRotation.z, rb.transform.localRotation.w);

        if (isDragged)
        {
            rotSpeed = (pos2.y - pos1.y) * speed / ((end - start)*100);
            Debug.Log(rotSpeed);
            isDragged = false;
            isRotating = true;
            count = 0;
        }


        if (isRotating)
        {
            if((rotSpeed >= -10.0f))
            {
                if (rotSpeed >= -1.0f)
                {
                    double difference=2000;
                    if (count ==0)
                    {
                        for(int i=0; i<angels.Length; i++)
                        {
                            if ((Mathf.Abs((float)(actualRotation - angels[i])) < difference)&& actualRotation - angels[i]>=0)
                            {
                                if (!((GameHandler.sideList[i]==3) && GameHandler.allRem)&&!((GameHandler.sideList[i] == 3) && GameHandler.noRem))
                                {
                                    difference = actualRotation - angels[i];
                                    endAngel = angels[i];
                                    Debug.Log("differenz: "+difference);
                                    Debug.Log("endwinkel: " + (float)endAngel);
                                    GameHandler.task = i;
                                }
                            }
                        }
                        rotSpeed = -(float)difference / 50;
                    }
                    if(count == 50)
                    {
                        actualRotation = (float)endAngel;
                        rotSpeed = 0;
                        isRotating = false;
                        GameHandler.RollTurned = true;
                    }
                    count++;
                }
                else
                {
                    rotSpeed += slow2;
                    //actualRotation += rotSpeed;
                }
            }
            else
            {
                rotSpeed+=slow;
                //actualRotation += rotSpeed;
            }
        }
        

//rotSpeed = 1;
        actualRotation += rotSpeed;

        rb.transform.eulerAngles = new Vector3(rb.transform.eulerAngles.x, rb.transform.eulerAngles.y, actualRotation);


    }

    void OnMouseDown()
    {
        //rb.transform.rotation= new Quaternion(rb.transform.localRotation.x, rb.transform.localRotation.y, rb.transform.localRotation.z, rb.transform.localRotation.w +10);
        //rb.transform.rotation.z = transform.rotation.z + 10;

        pos1 = Input.mousePosition;
        start = Time.time;
        ausgabe = "input get";
    }

    void OnMouseUp()
    {
        pos2 = Input.mousePosition;
        end = Time.time;
        if(pos1.y > pos2.y)
        {
            isDragged = true;
            ausgabe = "input getup";
            
        }
        
        
        
    }
}
