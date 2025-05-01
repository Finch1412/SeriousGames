using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SheepClickHandler : MonoBehaviour
{
    private Camera cam;
    public TMP_Text sheepcount;
    public TMP_Text badClicks;
    public int badClickCount = 0;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
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
                }

            }
        }

        badClicks.text = "Incorrect Clicks: " + badClickCount;
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
    }
}