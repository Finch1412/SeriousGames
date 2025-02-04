using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Uncomment if using TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText; // Use for standard UI Text
    // public TMP_Text timerText; // Uncomment for TextMeshPro

    public float timeRemaining = 10f;
    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                UpdateTimerDisplay(timeRemaining);
                OnTimerEnd(); // Call the event
            }
        }
    }

    void UpdateTimerDisplay(float time)
    {
        timerText.text = Mathf.Ceil(time).ToString(); // Display whole seconds
    }

    void OnTimerEnd()
    {
        Debug.Log("Timer ended! Trigger event here.");
        // Add your event here, e.g., Game Over, Load Scene, etc.
        SceneManager.LoadScene("10Seconds");
    }
}
