using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Scout[] scouts;

    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

        bool buttonPressed = false;

        if (Input.GetButton("Xbox_1_A"))
        {
            scouts[0].Result = true;
            buttonPressed = true;
        }
        else if (Input.GetButton("Xbox_1_B"))
        {
            scouts[0].Result = false;
            buttonPressed = true;
        }
        else if (Input.GetButton("Xbox_1_X"))
        {
            scouts[0].Climb = false;
            buttonPressed = true;
        }
        else if (Input.GetButton("Xbox_1_Y"))
        {
            scouts[0].Climb = true;
            buttonPressed = true;
        }
        else if (Input.GetButton("Xbox_1_RB"))
        {
            scouts[0].NumberOfGears++;
            buttonPressed = true;
        }
        else if (Input.GetButton("Xbox_1_LB"))
        {
            scouts[0].NumberOfShots++;
            buttonPressed = true;
        } 

        if(buttonPressed)
        {
            scouts[0].LightOn();
        } else
        {
            scouts[0].LightOff();
        }       
    }
}
