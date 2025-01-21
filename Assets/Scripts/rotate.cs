using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)]
    private float xSpeed = 0f;

    [SerializeField]
    [Range(0f, 10f)]
    private float ySpeed = 0f;

    [SerializeField]
    [Range(0f, 10f)]
    private float zSpeed = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xSpeed,ySpeed,zSpeed);
    }
}
