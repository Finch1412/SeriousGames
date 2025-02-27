using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Hole : MonoBehaviour
{
    public int holeStage;

    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;
    public GameObject floor5;

    public bool isNearHole = false;

    public GameObject digText;

    // Start is called before the first frame update
    void Start()
    {
        holeStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearHole)
        {
            if (Input.GetMouseButtonDown(0))
            {
                holeStage = holeStage + 1;

                Dig();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNearHole = true;
            digText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNearHole = false;
            digText.SetActive(false);
        }
    }
    private void Dig()
    {
        if (holeStage == 0)
        {
            floor1.SetActive(true);
            floor2.SetActive(false);
            floor3.SetActive(false);
            floor4.SetActive(false);
            floor5.SetActive(false);
        }
        if (holeStage == 1)
        {
            floor1.SetActive(false);
            floor2.SetActive(true);
            floor3.SetActive(false);
            floor4.SetActive(false);
            floor5.SetActive(false);
        }
        if(holeStage == 2)
        {
            floor1.SetActive(false);
            floor2.SetActive(false);
            floor3.SetActive(true);
            floor4.SetActive(false);
            floor5.SetActive(false);
        }
        if (holeStage == 3)
        {
            floor1.SetActive(false);
            floor2.SetActive(false);
            floor3.SetActive(false);
            floor4.SetActive(true);
            floor5.SetActive(false);
        }
        if (holeStage >= 4)
        {
            floor1.SetActive(false);
            floor2.SetActive(false);
            floor3.SetActive(false);
            floor4.SetActive(false);
            floor5.SetActive(true);
        }
    }
}
