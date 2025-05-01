using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class SheepClickHandler : MonoBehaviour
{
    private Camera cam;
    public TMP_Text sheepcount;
    public TMP_Text badClicks;
    public int badClickCount = 0;
    public SheepGameManager gameManager;
    //public TMP_Text loseText;
    public AudioSource audioSource;
    public AudioClip oi;
    public AudioClip correct;
    

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (gameManager.gameRunning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    SheepFSM sheep = hit.collider.GetComponentInParent<SheepFSM>();
                    if (sheep != null && sheep.sheep.lambing)
                    {
                        StartCoroutine(HandleFoundSheep(sheep.gameObject));
                    }
                    else
                    {
                        badClickCount++;
                        audioSource.PlayOneShot(oi);

                    }

                }
            }
        }

        badClicks.text = "Incorrect Clicks: " + badClickCount + "/3";

        //if (badClickCount >= 3)
        //{
        //    gameManager.gameRunning = false;

        //    if (loseText != null)
        //    {
        //        loseText.text = "All Ewes Pend Up! Good Job! Time: " + gameManager.FormatTime(timer);
        //        loseText.gameObject.SetActive(true);
        //    }
        //}
    }

    private System.Collections.IEnumerator HandleFoundSheep(GameObject sheep)
    {
        Vector3 originalScale = sheep.transform.localScale;
        float t = 0f;
        float duration = 0.5f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float scale = Mathf.Lerp(1f, 0f, t / duration);
            sheep.transform.localScale = originalScale * scale;
            yield return null;
        }

        SheepGameManager.Instance.FoundSheep();
        Destroy(sheep);
        audioSource.PlayOneShot(correct);
    }
}