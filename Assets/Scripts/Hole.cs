using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
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

    public bool holeIsDug;

    public bool dogCollected;

    public GameObject dedDog;

    public GameObject buryDogTXT;

    public GameObject dogInHole;

    public bool dogBuried = false;

    public bool keepsakeTaken = false;

    public GameObject takeKeepsakeTXT;

    public GameObject collar;
    public GameObject black;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        holeStage = 0;

        holeIsDug = false;
        
        buryDogTXT.SetActive(false);

        dogInHole.SetActive(false);
        takeKeepsakeTXT.SetActive(false);
        collar.SetActive(false);
        black.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dogCollected = dedDog.GetComponent<DedDog>().dogIsCollected;

        if (dogBuried && !keepsakeTaken && isNearHole)
        {
            takeKeepsakeTXT.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                keepsakeTaken = true;
                Debug.Log("Treasures collar");
                //takeKeepsakeTXT.SetActive(false);
            }
        }
        if (keepsakeTaken)
        {
            takeKeepsakeTXT.SetActive(false);
            collar.SetActive(true);
            black.SetActive(true);
            player.SetActive(false);
            Time.timeScale = 0;
        }

        //dig hole
        if (isNearHole)
        {
            if (Input.GetMouseButtonDown(0))
            {
                holeStage = holeStage + 1;

                Dig();
            }
        }

        //bury dog
        if (isNearHole && dogCollected && !dogBuried)
        {
            buryDogTXT.SetActive(true);
            if (Input.GetMouseButtonDown (0))
            {
                dogInHole.SetActive(true);
                dogBuried = true;
            }
        }
        else
        {
            buryDogTXT.SetActive(false);
        }
        if (!isNearHole && !dogBuried)
        {
            buryDogTXT.SetActive(false);
        }

        //taking off the keepsake
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNearHole = true;
            if (holeStage <= 3)
            {
                digText.SetActive(true);
            }
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
            holeIsDug = true;
        }
    }
}
