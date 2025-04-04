using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public Animator Animator;
    public ItemInBox itemInBox;

    public GameObject loot;

    public float playerCut;
    public float devCut;



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
                itemInBox.devTotal += devCut;
                

                itemInBox.isSpinningDone = false;
                //itemInBox.hasStartedSpawning = false;

            }

        }
    }
}
