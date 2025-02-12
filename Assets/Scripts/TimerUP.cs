using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUP : MonoBehaviour
{
    public TMP_Text timerText; // Assign a UI Text element in the Inspector
    private float elapsedTime = 0f;
    private bool isRunning = true;

    public bool gameOver = false;

    void Update()
    {
        if (gameOver == false)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = elapsedTime.ToString("F2"); // Displays time with 2 decimal places
    }
}
