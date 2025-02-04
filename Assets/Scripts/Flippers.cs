using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Flippers : MonoBehaviour
{
    [SerializeField]
    private float xSpeed = 0f;

    [SerializeField]
    private float ySpeed = 0f;

    [SerializeField]
    private float zSpeed = 0f;

    [SerializeField]
    private float xSpeed2 = 0f;

    [SerializeField]
    private float ySpeed2 = 0f;

    [SerializeField]
    private float zSpeed2 = 0f;

    private bool mouseLIsDown = false;

    private bool mouseRIsDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseLIsDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseLIsDown = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            mouseRIsDown = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            mouseRIsDown = false;
        }


        if (mouseLIsDown)
        {
            transform.Rotate(xSpeed, ySpeed, zSpeed);
        }

        if (mouseRIsDown)
        {
            transform.Rotate(xSpeed2, ySpeed2, zSpeed2);
        }


   

    }
}
