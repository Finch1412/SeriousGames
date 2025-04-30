using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPressDisplay : MonoBehaviour
{
    public TMP_Text keyText; // Assign in the Inspector
    private CanvasGroup canvasGroup;
    private Queue<string> keyQueue = new Queue<string>();
    private float fadeDuration = 2f;
    private float fadeStartTime;
    private bool isFading = false;

    void Start()
    {
        canvasGroup = keyText.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = keyText.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 1;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            keyQueue.Clear();
        }

        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key) && key >= KeyCode.A && key <= KeyCode.Z)
                {
                    keyQueue.Enqueue(key.ToString());
                    if (!isFading)
                    {
                        fadeStartTime = Time.time;
                        isFading = true;
                    }
                    UpdateKeyText();
                    break;
                }
            }
        }

        if (isFading && keyQueue.Count > 0)
        {
            if (Time.time - fadeStartTime >= fadeDuration)
            {
                keyQueue.Dequeue();
                UpdateKeyText();
                fadeStartTime = Time.time;

                if (keyQueue.Count == 0)
                {
                    isFading = false;
                }
            }
        }
    }

    void UpdateKeyText()
    {
        string[] keys = keyQueue.ToArray();
        System.Text.StringBuilder formatted = new System.Text.StringBuilder();

        float currentSizePercent = 100f;

        for (int i = 0; i < keys.Length; i++)
        {
            if (i == 0)
            {
                // Full size, no tag
                formatted.Append(keys[i]);
            }
            else
            {
                // Decrease by 50% for second, then 5% for each additional letter
                if (i == 1)
                    currentSizePercent = 50f;
                else
                    currentSizePercent = Mathf.Max(currentSizePercent - 5f, 1f);

                formatted.Append($"<size={currentSizePercent}%>{keys[i]}</size>");
            }
        }

        keyText.text = formatted.ToString();
    }
}