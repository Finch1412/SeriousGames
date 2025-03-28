using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class KeyPressDisplay : MonoBehaviour
{
    public TMP_Text keyText; // Assign in the Inspector
    private CanvasGroup canvasGroup;
    private Coroutine fadeCoroutine;

    void Start()
    {
        canvasGroup = keyText.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = keyText.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0; // Start invisible
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    DisplayKey(key.ToString());
                    break;
                }
            }
        }
    }

    void DisplayKey(string key)
    {
        keyText.text = key;
        canvasGroup.alpha = 1;
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText()
    {
        float duration = 3f;
        float startAlpha = 1;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, elapsedTime / duration);
            yield return null;
        }

        canvasGroup.alpha = 0;
    }
}

