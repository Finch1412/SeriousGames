using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepGameManager : MonoBehaviour
{
    public static SheepGameManager Instance;

    public GameObject mother1;
    public GameObject mother2;
    public GameObject mother3;

    public int foundSheepCount = 0;
    public TMP_Text foundSheepText; // Optional extra counter
    public TMP_Text sheepcount;     // Displays "Lambing Ewes Found: X/3"
    public TMP_Text timerText;      // Timer display
    public TMP_Text victoryText;    // Shown when player wins

    private float timer = 0f;
    public bool gameRunning = true;

    public TMP_Text loseText;

    public SheepClickHandler SheepClickHandler;

    //public AudioSource audioSource;
    //public AudioClip lose;


    void Awake()
    {
        //SheepClickHandler = gameObject.GetComponent<SheepClickHandler>();
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (victoryText != null)
            victoryText.gameObject.SetActive(false);
        if(loseText != null)
        {
            loseText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (SheepClickHandler.badClickCount >= 3)
        {
            Debug.Log("FAIL");
            gameRunning = false;
            //audioSource.PlayOneShot(lose);

            if (loseText != null)
            {
                loseText.text = "You made a right Pigs Ear of that!: " + FormatTime(timer);
                loseText.gameObject.SetActive(true);
            }
        }

        if (foundSheepCount == 0)
        {
            mother1.SetActive(false);
            mother2.SetActive(false);
            mother3.SetActive(false);
        }
        if(foundSheepCount == 1)
        {
            mother1.SetActive(true);
            mother2.SetActive(false);
            mother3.SetActive(false);
        }
        if(foundSheepCount == 2)
        {
            mother1.SetActive(true);
            mother2.SetActive(true);
            mother3.SetActive(false);
        }
        if (foundSheepCount == 3)
        {
            mother1.SetActive(true);
            mother2.SetActive(true);
            mother3.SetActive(true);
        }

        if (gameRunning)
        {
            timer += Time.deltaTime;
            if (timerText != null)
                timerText.text = FormatTime(timer);

            if (sheepcount != null)
                sheepcount.text = "Lambing Ewes Found: " + foundSheepCount + "/3";


            
        }
    }

    public void FoundSheep()
    {
        foundSheepCount++;

        if (foundSheepText != null)
            foundSheepText.text = "Found Sheep: " + foundSheepCount;

        if (sheepcount != null)
            sheepcount.text = "Lambing Ewes Found: " + foundSheepCount + "/3";

        if (foundSheepCount >= 3)
        {
            
            gameRunning = false;

            if (victoryText != null)
            {
                victoryText.text = "All Ewes Pend Up! Good Job! Time: " + FormatTime(timer);
                victoryText.gameObject.SetActive(true);
            }
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}