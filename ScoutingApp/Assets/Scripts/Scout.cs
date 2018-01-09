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
    public int NumberOfCubesInSwitch;
    public int NumberOfCubesInScale;
    public int NumberOfCubesInVault;
    public bool Climb;
    public bool Result;
    //xbox A = win, xbox B = lost, xbox y = climb, xbox x = vault, xbox rb = switch, xbox lb = scale
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

        NumberOfCubesInSwitch = 0;
        NumberOfCubesInScale = 0;
        NumberOfCubesInVault = 0;
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

            if (child.name.Contains("Switch"))
            {
                score.GetComponent<Text>().text = NumberOfCubesInSwitch.ToString();
                presses.GetComponent<Text>().text = NumberOfCubesInSwitch.ToString();
            }
            else if (child.name.Contains("Vault"))
            {
                score.GetComponent<Text>().text = NumberOfCubesInVault.ToString();
                presses.GetComponent<Text>().text = NumberOfCubesInVault.ToString();//NumberOfCubesInSwitch.ToString();
            }
            else if (child.name.Contains("Scale"))
            {
                score.GetComponent<Text>().text = NumberOfCubesInScale.ToString();
                presses.GetComponent<Text>().text = NumberOfCubesInScale.ToString();
            }
            else if (child.name.Contains("Climb"))
            {

                if (Climb)
                {
                    presses.GetComponent<Text>().text = "Climbed";
                    score.GetComponent<Text>().text = "30";
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
        NumberOfCubesInSwitch = 0;
        NumberOfCubesInScale = 0;
        NumberOfCubesInVault = 0;
        Climb = false;
        Result = false;
    }
}
