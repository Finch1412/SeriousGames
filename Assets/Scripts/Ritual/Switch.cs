using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public Animator animator;

    public bool switchOn = true;

    public GameObject redNeckRayCast;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;   
    public GameObject light5;

    public int flickCount = 0;

    public GameObject panicEffects;

    public TMP_Text flickCountText;

    public bool lookingAtSwitch = false;

    public GameObject questText;
    public GameObject completeText;
    public GameObject Counter;

    public bool gameComplete = false;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateFlickCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchOn)
        {
            light1.SetActive(true);
            light2.SetActive(true);
            light3.SetActive(true);
            light4.SetActive(true);
            light5.SetActive(true);
            
        }
        if (!switchOn)
        {
            light1.SetActive(false);
            light2.SetActive(false);
            light3.SetActive(false);
            light4.SetActive(false);
            light5.SetActive(false);
            
        }

        if (flickCount > 0)
        {
            panicEffects.GetComponent<PanicModeURP>().panicMode = true;
        }
        if (flickCount == 5)
        {
            CompleteQuest();
            Counter.SetActive(false);

        }
        
        if (!gameComplete)
        {
            UpdateFlickCountText();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (lookingAtSwitch)
            {
                if (!switchOn)
                {
                    switchOn = true;
                    animator.SetTrigger("On");
                }
                else
                {
                    switchOn = false;
                    animator.SetTrigger("Off");
                    flickCount = flickCount + 1;
                    this.GetComponent<Collider>().enabled = false;
                    this.GetComponent<Collider>().enabled = true;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == redNeckRayCast)
        {
            Debug.Log("looking at switch");
            lookingAtSwitch = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == redNeckRayCast)
        {
            lookingAtSwitch = false;
        }
    }
    void UpdateFlickCountText()
    {
        if (flickCountText != null)
        {
            flickCountText.text = flickCount + "/5";  // Display flick count as "x/5"
        }
    }

    void CompleteQuest()
    {
        gameComplete = true;
        questText.SetActive(false);
        completeText.SetActive(true);
        Counter.SetActive(false);
        //this.gameObject.GetComponent<Collider>().enabled = false;
        //lookingAtSwitch = false ;
        flickCount = 0;
        panicEffects.GetComponent<PanicModeURP>().panicMode = false;

    }
}
