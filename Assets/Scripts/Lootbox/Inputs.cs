using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inputs : MonoBehaviour
{
    public Animator Animator;
    public ItemInBox itemInBox;

    public GameObject loot;

    public float playerCut;
    public float devCut;

    public GameObject priceText;



    // Start is called before the first frame update
    void Start()
    {
        itemInBox = FindAnyObjectByType<ItemInBox>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!itemInBox.isSpinningDone)
            {
                Animator.SetBool("IsSpinning", true);
                priceText.SetActive(false);
            }
            else
            {
                Animator.SetBool("IsSpinning", false);
                
                GameObject[] lootObjects = GameObject.FindGameObjectsWithTag("Loot");
                foreach (GameObject loot in lootObjects)
                {
                    Destroy(loot, 0.7f);
                }

                playerCut = itemInBox.rewardValue * 0.8f;
                
                devCut = itemInBox.rewardValue * 0.2f;
                

                itemInBox.playerTotal += playerCut;
                Math.Round(itemInBox.playerTotal, 2);
                itemInBox.devTotal += devCut;
                Math.Round(itemInBox.devTotal, 2);

                itemInBox.sellText.SetActive(false);
                priceText.SetActive(true);


                itemInBox.isSpinningDone = false;
                //itemInBox.hasStartedSpawning = false;

            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!itemInBox.isSpinningDone)
            {
                Animator.SetBool("IsSpinning", true);
                priceText.SetActive(false);
            }
            else
            {
                Animator.SetBool("IsSpinning", false);

                GameObject[] lootObjects = GameObject.FindGameObjectsWithTag("Loot");
                foreach (GameObject loot in lootObjects)
                {
                    Destroy(loot, 0.7f);
                }

                playerCut = itemInBox.rewardValue * 0.8f;

                devCut = itemInBox.rewardValue * 0.2f;


                itemInBox.playerTotal += playerCut;
                Math.Round(itemInBox.playerTotal, 2);
                itemInBox.devTotal += devCut;
                Math.Round(itemInBox.devTotal, 2);

                itemInBox.sellText.SetActive(false);
                priceText.SetActive(true);


                itemInBox.isSpinningDone = false;
                //itemInBox.hasStartedSpawning = false;

            }

        }
    }
}
