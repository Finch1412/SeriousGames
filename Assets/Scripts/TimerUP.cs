using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerUP : MonoBehaviour
{
    public TMP_Text timerText; // Assign a UI Text element in the Inspector
    public GameObject restartText;
    private float elapsedTime = 0f;
    public bool isRunning = false;

    public bool gameOver = false;

    void Update()
    {
        if(isRunning)
        {
            if (gameOver == false)
            {
                elapsedTime += Time.deltaTime;
                UpdateTimerDisplay();
            }

            if (gameOver == true)
            {
                restartText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("DuoTone");
                }
            }
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = elapsedTime.ToString("F2"); // Displays time with 2 decimal places
    }
}
