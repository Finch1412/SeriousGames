using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAlphabet : MonoBehaviour
{

    public Animator animator;

    public List <string> inputList = new List <string>();

    public bool isAnimPlaying;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            inputList.Add("A");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            inputList.Add("B");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            inputList.Add("C");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            inputList.Add("D");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            inputList.Add("E");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            inputList.Add("F");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            inputList.Add("G");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            inputList.Add("H");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inputList.Add("I");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            inputList.Add("J");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            inputList.Add("K");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inputList.Add("L");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            inputList.Add("M");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            inputList.Add("N");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            inputList.Add("O");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            inputList.Add("P");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inputList.Add("Q");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            inputList.Add("R");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inputList.Add("S");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            inputList.Add("T");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inputList.Add("U");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputList.Add("V");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            inputList.Add("W");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            inputList.Add("X");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            inputList.Add("Y");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inputList.Add("Z");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
        {
            isAnimPlaying = false;
        }


        if (inputList.Count > 0)
        {
            if (!isAnimPlaying)
            {
                isAnimPlaying = true;
                animator.SetTrigger(inputList[0]);
                inputList.RemoveAt(0);
                
            }
        }

        

        
    }
}
