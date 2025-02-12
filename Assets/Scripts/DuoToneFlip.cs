using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuoToneFlip : MonoBehaviour
{
    
    public Material orangeMat;
    public Material blueMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "DuoOrange")
        {
            gameObject.GetComponent<Renderer>().material = orangeMat;
        }
        else if (gameObject.tag == "DuoBlue")
        {
            gameObject.GetComponent<Renderer>().material = blueMat;
        }
    }
}
