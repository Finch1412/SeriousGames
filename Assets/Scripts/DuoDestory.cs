using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DuoDestory : MonoBehaviour
{

    [SerializeField]
    private float WallSpeed = 20f;

    private GameObject gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, WallSpeed) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 1f);

        if (gameObject.tag == "BlueWall")
        {
            if (other.tag == "DuoOrange")
            {
                Destroy(other.gameObject, 1f);

                StartCoroutine(shrinkObject(other.gameObject));

                gameManager.GetComponent<TimerUP>().gameOver = true;
            }
            if (gameObject.tag == "OrangeWall")
            {
                if (other.tag == "DuoBlue")
                {
                    Destroy(other.gameObject, 1f);

                    StartCoroutine(shrinkObject(other.gameObject));

                    gameManager.GetComponent<TimerUP>().gameOver = true;

                }
            }
        }
    }

    private IEnumerator shrinkObject(GameObject other)
    {
        while (other.transform.localScale.x > 0)
        {
            other.transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime;
            yield return null;
        }
    }
}
