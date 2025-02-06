using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class RandomFactTurtle : MonoBehaviour
{
    [SerializeField]
    private TMP_Text factBox;

    public int factNumber;

    // Start is called before the first frame update
    void Start()
    {
        factNumber = Random.Range(0, 5);
        switch (factNumber)
        {
            case 0:
                factBox.text = "Turtles are reptiles.";
                break;
            case 1:
                factBox.text = "Turtles are cold-blooded.";
                break;
            case 2:
                factBox.text = "Turtles have a hard shell.";
                break;
            case 3:
                factBox.text = "Turtles lay eggs.";
                break;
            case 4:
                factBox.text = "Turtles can live in water and on land.";
                break;
            default:
                factBox.text = "Turtles are awesome!";
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
