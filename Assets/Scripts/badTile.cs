using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class badTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Safe")
        {
            UnityEngine.Debug.Log("We is Safe");
        }
        if (other.gameObject.tag == "Danger")
        {
            Destroy(gameObject,1f);
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Danger")
        {
            transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime;
        }
    }
}