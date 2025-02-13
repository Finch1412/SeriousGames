using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuoToneFlip : MonoBehaviour
{
    [SerializeField]
    private GameObject leftObj;

    [SerializeField]
    private GameObject rightObj;

    public Material orangeMat;

    public Material blueMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the left and right objects are not null, allow mouse controls.
        if(leftObj != null && rightObj != null)
        {
            //Changes the colour of the objects to orange or blue based on the tag of the object
            if (leftObj.tag == "DuoOrange")
            {
                leftObj.GetComponent<Renderer>().material = orangeMat;
            }
            else if (leftObj.tag == "DuoBlue")
            {
                leftObj.GetComponent<Renderer>().material = blueMat;
            }
            if (rightObj.tag == "DuoOrange")
            {
                rightObj.GetComponent<Renderer>().material = orangeMat;
            }
            else if (rightObj.tag == "DuoBlue")
            {
                rightObj.GetComponent<Renderer>().material = blueMat;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (leftObj.tag == "DuoOrange")
                {
                    leftObj.tag = "DuoBlue";
                }
                else if (leftObj.tag == "DuoBlue")
                {
                    leftObj.tag = "DuoOrange";
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (rightObj.tag == "DuoOrange")
                {
                    rightObj.tag = "DuoBlue";
                }
                else if (rightObj.tag == "DuoBlue")
                {
                    rightObj.tag = "DuoOrange";
                }
            }
        }
    }
}
