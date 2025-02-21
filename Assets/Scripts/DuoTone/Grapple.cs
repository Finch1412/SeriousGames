using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    public GameObject grapplePoint;

    //public Vector3 playerLocal;

    //public Vector3 GrappleLocal;
    //private Transform target;
    public float speed = 1.0f;
    public GameObject Player;
    public bool isGrappling = false;
    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E))
        {
            isGrappling=true;
            transform.position = Vector3.MoveTowards(transform.position, grapplePoint.transform.position, step);
            
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            isGrappling=false;
        }

        if (isGrappling)
        {
            Player.GetComponent<FirstPersonController>().Gravity = 0;
            characterController.enabled = false;
        }
        else
        {
            Player.GetComponent<FirstPersonController>().Gravity = -15;
            characterController.enabled = true;
        }
    }
}
