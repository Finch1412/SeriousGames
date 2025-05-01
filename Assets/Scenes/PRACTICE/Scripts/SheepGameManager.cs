using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepGameManager : MonoBehaviour
{
    public static SheepGameManager Instance;

    public int foundSheepCount = 0;
    public TMP_Text foundSheepText; // or TMP_Text if using TextMeshPro
    public TMP_Text sheepcount;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        sheepcount.text = "Lambing Ewes Found: " + foundSheepCount + "/3";
    }

    public void FoundSheep()
    {
        foundSheepCount++;
        foundSheepText.text = "Found Sheep: " + foundSheepCount;
    }
}