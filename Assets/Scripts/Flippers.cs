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

    private bool mouseIsDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseIsDown = true;
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseIsDown = false;
        }
        if (mouseIsDown)
        {
            transform.Rotate(xSpeed, ySpeed, zSpeed);
        }

    }
}
