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
                factBox.text = "All seven species of Sea Turtles are considered threatened or endangered. Two are critically endangered (hawksbill and Kemp’s ridley), one is endangered (green and and three are threatened (leatherback, olive ridley, and loggerhead). Flatbacks are listed as data deficient on the IUCN Red List but are listed as endangered in Australia.";
                break;
            case 1:
                factBox.text = "It is estimated that only one out of 1,000 hatchlings survives to be an adult. They have many natural predators including birds, crabs, fish, and mammals like racoons. But the female adults can lay thousands of eggs over their lifetimes, so at least a few of them survive to maintain the species.\r\n\r\n";
                break;
            case 2:
                factBox.text = "The sex of sea turtles, like other reptiles, depends on the temperature in the nest. That temperature is generally around 82 degrees F (29 degrees C) though that can vary by species and location";
                break;
            case 3:
                factBox.text = "Sea turtles don’t have a favorite food (though most will eat jellyfish.) Each species focuses on different prey for food; the leatherback eats mostly jellyfish, greens primarily eat seagrass, loggerheads prefer crustaceans, and hawksbills eat primarily sea sponges..";
                break;
            case 4:
                factBox.text = "Some sea turtles migrate very long distances while others stay close to home. Leatherbacks and loggerheads can travel thousands of miles each year, while greens and olive ridleys have shorter migrations, while hawksbills rarely leave a relatively small area.";
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
