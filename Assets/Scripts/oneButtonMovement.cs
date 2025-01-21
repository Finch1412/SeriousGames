using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class oneButtonMovement : MonoBehaviour
{

    private int noClicks = 0;

    private bool isCounting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(noClicks == 0)
            {
                StartCoroutine("CountClicks");
            }
            if (noClicks >= 1)
            {
                StopCoroutine("CountClicks");
                Debug.Log("counting stopped");
                StartCoroutine("CountClicks");
                Debug.Log("CountingStarted");

            }
            noClicks = noClicks + 1;
            isCounting = true; 

            if (noClicks == 5)
            {
                StopCoroutine("CountClicks");
                noClicks = 0;
                Debug.Log("TooManyClicks");
            }
        }
        
    }

    void Forward()
    {
        transform.localPosition += new Vector3(0, 0, 1);
        Debug.Log("Forward");
    }

    void Back()
    {
        transform.localPosition += new Vector3(0, 0, -1);
        Debug.Log("Back");
    }

    void Left()
    {
        transform.localPosition += new Vector3(-1, 0, 0);
        Debug.Log("Left");
    }

    void Right()
    {
        transform.localPosition += new Vector3(1, 0, 0);
        Debug.Log("Right");
    }

    private IEnumerator CountClicks()
    {
        yield return new WaitForSeconds(1);
        if (noClicks == 1)
        {
            Forward();
        }
        if (noClicks == 2)
        {
            Back();
        }
        if (noClicks == 3)
        {
            Left();
        }
        if (noClicks == 4)
        {
            Right();
        }

        noClicks = 0;
    }
    
}

