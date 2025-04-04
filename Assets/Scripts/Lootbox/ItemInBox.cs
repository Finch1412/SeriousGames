using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInBox : MonoBehaviour
{
    public GameObject itemPrefab;
    public Animator lootBoxAnimator;
    public bool isSpinningDone = false;
    public bool isClosed = false;

    public bool hasStartedSpawning = false;

    public GameObject reward_01;
    public GameObject reward_02;
    public GameObject reward_03;
    public GameObject reward_04;
    public GameObject reward_05;

    public int rewardRoll;
    public float rewardValue = 0f;

    public TMP_Text yourEarnings;
    public TMP_Text devEarnings;

    public float playerTotal = 10f;
    public float devTotal = 0f;

    public TMP_Text priceText;
    public GameObject sellText;

    void Update()
    {
        // Start coroutine only once when spinning starts
        if (lootBoxAnimator.GetCurrentAnimatorStateInfo(0).IsName("Spinning") && !hasStartedSpawning)
        {
            StartCoroutine(SpawnItem());
            playerTotal -= 2f;
            devTotal += 2f;
            hasStartedSpawning = true;
            isClosed = false;
        }

        // Stop spinning when space is pressed after spawning is done
        if (isSpinningDone && Input.GetKeyDown(KeyCode.Space))
        {
            lootBoxAnimator.SetBool("IsSpinning", false);
        }

        if (isSpinningDone && Input.GetMouseButtonDown(0))
        {
            lootBoxAnimator.SetBool("IsSpinning", false);
        }

        if (lootBoxAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            hasStartedSpawning = false;
        }

        //if(lootBoxAnimator.GetCurrentAnimatorStateInfo(0).IsName("Close") && !isClosed)
        //{
        //    playerTotal += rewardValue/0.8f;
        //    devTotal += rewardValue / 0.2f;
        //    isClosed = true;
        //}
        UpdateEarningsText();

    }

    private IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(5.5f);

        

        rewardRoll = Random.Range(0, 100);
        if (rewardRoll < 50) // 50% chance for reward_01
        {
            itemPrefab = reward_01;
            rewardValue = 0.20f;
            priceText.text = "£" + rewardValue.ToString() + "0";
        }
        else if (rewardRoll < 80) // 25% chance for reward_02
        {
            itemPrefab = reward_02;
            rewardValue = 0.50f;
            priceText.text = "£" + rewardValue.ToString() + "0";
        }
        else if (rewardRoll < 90) // 15% chance for reward_03
        {
            itemPrefab = reward_03;
            rewardValue = 1.80f;
            priceText.text = "£" + rewardValue.ToString() + "0";
        }
        else if (rewardRoll < 99) // 8% chance for reward_04
        {
            itemPrefab = reward_04;
            rewardValue = 8.00f;
            priceText.text = "£" + rewardValue.ToString() + ".00";
        }
        else // 1% chance for reward_05
        {
            itemPrefab = reward_05;
            rewardValue = 100.00f;
            priceText.text = "£" + rewardValue.ToString() + ".00";
        }

        Instantiate(itemPrefab, transform.position, Quaternion.identity);
        isSpinningDone = true;

        sellText.SetActive(true);
        


        UpdateEarningsText(); 
    }

    private void UpdateEarningsText() 
    {
        yourEarnings.text = "£" + playerTotal.ToString(); 
        devEarnings.text = "£" + devTotal.ToString();      

        yourEarnings.color = playerTotal >= 0 ? Color.green : Color.red; 
        devEarnings.color = devTotal >= 0 ? Color.green : Color.red;     
    }
}

