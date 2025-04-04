using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInBox : MonoBehaviour
{
    public GameObject itemPrefab;
    public Animator lootBoxAnimator;
    public bool isSpinningDone = false;

    public bool hasStartedSpawning = false;

    void Update()
    {
        // Start coroutine only once when spinning starts
        if (lootBoxAnimator.GetCurrentAnimatorStateInfo(0).IsName("Spinning") && !hasStartedSpawning)
        {
            StartCoroutine(SpawnItem());
            hasStartedSpawning = true;
        }

        // Stop spinning when space is pressed after spawning is done
        if (isSpinningDone && Input.GetKeyDown(KeyCode.Space))
        {
            lootBoxAnimator.SetBool("IsSpinning", false);
        }

        if (lootBoxAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            hasStartedSpawning = false;
        }
    }

    private IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(5.5f);
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
        isSpinningDone = true;
    }
}
