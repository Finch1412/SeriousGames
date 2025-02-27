using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedDog : MonoBehaviour
{
    public bool canPickUpDog;

    public bool isNearDog;

    public bool dogIsCollected;

    public GameObject gameManager;

    public GameObject collectDogTXT;
    // Start is called before the first frame update
    void Start()
    {
        collectDogTXT.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        canPickUpDog = gameManager.GetComponent<Hole>().holeIsDug;

        if (canPickUpDog)
        {
            if (isNearDog && !dogIsCollected)
            {
                collectDogTXT.SetActive(true);

                if (Input.GetMouseButton(0))
                {
                    dogIsCollected = true;
                }
            }
        }

        if (dogIsCollected)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            collectDogTXT.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isNearDog = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isNearDog = false;
            collectDogTXT?.SetActive(false);
        }
    }


}
