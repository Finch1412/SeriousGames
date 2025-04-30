using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class HandAlphabet : MonoBehaviour
{
    public Animator animator;
    public List<string> inputList = new List<string>();
    public bool isAnimPlaying;
    public TMP_Text keyText;

    void Update()
    {
        // Add letters A–Z to the list on keypress
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (key >= KeyCode.A && key <= KeyCode.Z && Input.GetKeyDown(key))
            {
                inputList.Add(key.ToString());
            }
        }

        // Reset all triggers and go to IDLE if Tab is held
        if (Input.GetKey(KeyCode.Tab))
        {
            animator.Play("IDLE");
            foreach (char c in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                animator.ResetTrigger(c.ToString());
                inputList.Clear();
                isAnimPlaying = false;
                keyText.SetText("");
            }
        }

        // Start playing next animation if not currently playing
        if (!isAnimPlaying && inputList.Count > 0)
        {
            StartCoroutine(PlayNextAnim());
        }
    }

    private IEnumerator PlayNextAnim()
    {
        string nextTrigger = inputList[0];
        inputList.RemoveAt(0);

        animator.SetTrigger(nextTrigger);
        isAnimPlaying = true;

        // Wait for animation to start
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
        {
            yield return null;
        }

        // Wait for animation to finish (back to IDLE)
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
        {
            yield return null;
        }

        isAnimPlaying = false;
    }
}
