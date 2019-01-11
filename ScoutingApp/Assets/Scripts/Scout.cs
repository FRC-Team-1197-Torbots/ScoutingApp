using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scout : MonoBehaviour
{
    public string myTeam;
    public Image IndicatorImage;

    [Header("Scout Specific Information")]
    public int NumberTeam;
    public string team;
    public int id;
    public Transform Table;
    public bool Auto;

    [Header("Raw Scores")]
    public int NumberOfBallsLow;
    public int NumberOfBallsMid;
    public int NumberOfBallsHigh;
    public int NumberOfDisksLow;
    public int NumberOfDisksMid;
    public int NumberOfDisksHigh;

    [Header("Match Number")]
    public int MatchNumber;
    public Text matchnum;

    [Header("Team Text")]
    public Text TeamNumberText;

    public bool CrossBaseline;
    public bool Climb;
    public bool Result;
    public string TeamNumber;
    public string quest;
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

        NumberOfBallsLow = 0;
        NumberOfBallsMid = 0;
        NumberOfBallsHigh = 0;
        NumberOfDisksLow = 0;
        NumberOfDisksMid = 0;
        NumberOfDisksHigh = 0;

        CrossBaseline = false;
        Climb = false;
        Result = false;
/*
        if(TeamNumberText)
        {
            TeamNumberText.text = "Team " + NumberTeam.ToString();
        }
        if(matchnum)
        {
            matchnum.text = "Match " + MatchNumber.ToString();
        }
    */
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
        if (matchnum)
        {
            matchnum.text = "Match " + MatchNumber.ToString();
        }
        if (TeamNumberText)
        {
            TeamNumberText.text = "Team " + NumberTeam.ToString();
        }
        for (int i = 0; i < Table.childCount; i++)
        {
            Transform child = Table.GetChild(i);
            Transform name = child.GetChild(0);
            Transform score = child.GetChild(1);
            Transform presses = child.GetChild(2);

            if (child.name.Contains("Switch"))
            {
                score.GetComponent<Text>().text = NumberOfBallsLow.ToString();
                presses.GetComponent<Text>().text = NumberOfBallsLow.ToString();
            }
            else if (child.name.Contains("Vault"))
            {
                score.GetComponent<Text>().text = NumberOfBallsHigh.ToString();
                presses.GetComponent<Text>().text = NumberOfBallsHigh.ToString();//NumberOfBallsLow.ToString();
            }
            else if (child.name.Contains("Scale"))
            {
                score.GetComponent<Text>().text = NumberOfBallsMid.ToString();
                presses.GetComponent<Text>().text = NumberOfBallsMid.ToString();
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
            else if (child.name.Contains("Baseline"))
            {
                if (CrossBaseline)
                {
                    score.GetComponent<Text>().text = "5";
                    presses.GetComponent<Text>().text = "Crossed";
                }
                else
                {
                    score.GetComponent<Text>().text = "0";
                    presses.GetComponent<Text>().text = "No Cross";
                }
            }
        }
    }

    public void setTeamNum(Text teamnum)
    {
        int Num;
        bool isNum = int.TryParse(teamnum.text, out Num);
        if (teamnum != null)
        {
            if (isNum)
            {
                NumberTeam = Convert.ToInt32(Num);
                //teamnum.GetComponent<Text>().text = "";
            }
        }

    }

    public void setMatch(Text matchnum)
    {
        int Num;
        bool isNum = int.TryParse(matchnum.text, out Num);
        if (matchnum != null)
        {
            if (isNum)
            {
                MatchNumber = Convert.ToInt32(Num);
            }
        }
    }

    

    public void setQuest(Text q)
    { 
        if (q != null)
        {
            quest = q.text.ToString();
            
            
        }
    }
    /*
    public void Clear()
    {
        Debug.Log("cleared");
        NumberOfBallsLow = 0;
        NumberOfBallsMid = 0;
        NumberofBallsHigh = 0;
        Climb = false;
        Result = false;
    } */
   
    public void decBallsLow()
    {
        NumberOfBallsLow--;
        
    }
    public void decBallsMid()
    {
        Debug.Log("Before: " + NumberOfBallsMid);
        NumberOfBallsMid--;
        Debug.Log("after: " + NumberOfBallsMid);
    }
    public void decBallsHigh()
    {
        NumberOfBallsHigh--;
    }
}
