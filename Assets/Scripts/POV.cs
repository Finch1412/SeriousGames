using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POV : MonoBehaviour
{

    public bool firstPerson = false;
    [SerializeField]
    private GameObject firstPersonCamera;
    [SerializeField]
    private GameObject thirdPersonCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!firstPerson)
            {
                firstPersonCamera.SetActive(true);
                thirdPersonCamera.SetActive(false);
                firstPerson = true;
            }
            else
            {
                firstPerson = false;
                firstPersonCamera.SetActive(false);
                thirdPersonCamera.SetActive(true);
            }
        }
    }

    
}
