using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Flippers2 : MonoBehaviour
{
    [SerializeField]
    private float xSpeed = 0f;

    [SerializeField]
    private float ySpeed = 0f;

    [SerializeField]
    private float zSpeed = 0f;

    //[SerializeField]
    //private float xSpeed2 = 0f;

    //[SerializeField]
    //private float ySpeed2 = 0f;

    //[SerializeField]
    //private float zSpeed2 = 0f;

    private bool mouseLIsDown = false;

    private bool mouseRIsDown = false;

    public bool useMouseR = false;

    public bool useMouseL = false;

    private bool shiftDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftDown = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftDown = false;
        }
        //if (shiftDown)
        //{
        //    xSpeed = xSpeed * -1;
        //    ySpeed = ySpeed * -1;
        //    zSpeed = zSpeed * -1;
        //    xSpeed2 = xSpeed2 * -1;
        //    ySpeed2 = ySpeed2 * -1;
        //    zSpeed2 = zSpeed2 * -1;
        //}

        if (useMouseL)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseLIsDown = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                mouseLIsDown = false;
            }
            if (mouseLIsDown)
            {
                if (shiftDown)
                {
                    transform.Rotate(new Vector3(xSpeed * -1, ySpeed * -1, zSpeed * -1) * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(new Vector3(xSpeed , ySpeed , zSpeed) * Time.deltaTime);
                }
            }
        }

        if (useMouseR)
        {
            if (Input.GetMouseButtonDown(1))
            {
                mouseRIsDown = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                mouseRIsDown = false;
            }
            if (mouseRIsDown)
            {
                if (shiftDown)
                {
                    transform.Rotate(new Vector3(xSpeed * -1, ySpeed * -1, zSpeed * -1) * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
                }
            }
        }

        
        //else
        //{
        //    xSpeed = xSpeed;
        //    ySpeed = ySpeed;
        //    zSpeed = zSpeed;
        //    xSpeed2 = xSpeed2;
        //    ySpeed2 = ySpeed2;
        //    zSpeed2 = zSpeed2;
        //}
        

       

    }
}
