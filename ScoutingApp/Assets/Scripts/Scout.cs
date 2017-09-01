using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scout : MonoBehaviour
{

    public Image IndicatorImage;

    [Header("Scout Specific Information")]
    public string team;
    public int id;
    public Transform Table;

    [Header("Raw Scores")]
    public int NumberOfGears;
    public int NumberOfShots;
    public bool Climb;
    public bool Result;

    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < Table.childCount; i++)
        {
            Transform child = Table.GetChild(i);

            Transform name = child.GetChild(0);
            Transform score = child.GetChild(1);
            Transform presses = child.GetChild(2);
            name.GetComponent<Text>().text = child.name;
            score.GetComponent<Text>().text = "0";
            presses.GetComponent<Text>().text = "0";
        }

        NumberOfGears = 0;
        NumberOfShots = 0;
        Climb = false;
        Result = false;
    }

    public void LightOn()
    {
        IndicatorImage.GetComponent<JoystickIndicator>().LightOn();
    }

    public void LightOff()
    {
        IndicatorImage.GetComponent<JoystickIndicator>().LightOff();
    }

    void Update()
    {
        for (int i = 0; i < Table.childCount; i++)
        {
            Transform child = Table.GetChild(i);

            Transform name = child.GetChild(0);
            Transform score = child.GetChild(1);
            Transform presses = child.GetChild(2);

            if (child.name.Contains("Gears"))
            {
                score.GetComponent<Text>().text = NumberOfGears.ToString();
                presses.GetComponent<Text>().text = NumberOfGears.ToString();
            }
            else if (child.name.Contains("Shooting"))
            {
                score.GetComponent<Text>().text = "0";
                presses.GetComponent<Text>().text = "0";//NumberOfGears.ToString();
            }
            else if (child.name.Contains("Shots"))
            {
                score.GetComponent<Text>().text = (NumberOfShots * (1.0f / 3.0f)).ToString();
                presses.GetComponent<Text>().text = NumberOfShots.ToString();
            }
            else if (child.name.Contains("Climb"))
            {

                if (Climb)
                {
                    presses.GetComponent<Text>().text = "Climbed";
                    score.GetComponent<Text>().text = "50";
                }
                else
                {
                    presses.GetComponent<Text>().text = "Not Climbed";
                    score.GetComponent<Text>().text = "0";
                }
            }
            else if (child.name.Contains("Result"))
            {
                if (Result)
                {
                    score.GetComponent<Text>().text = "2";
                    presses.GetComponent<Text>().text = "Win";
                }
                else
                {
                    score.GetComponent<Text>().text = "0";
                    presses.GetComponent<Text>().text = "Lose";
                }
            }
        }
    }

    public void Clear()
    {
        NumberOfGears = 0;
        NumberOfShots = 0;
        Climb = false;
        Result = false;
    }
}
