using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Super Hacky, eventually should store in database
/// </summary>
public class MatchInfo : MonoBehaviour
{
    private List<Match> Matches;
    public Text ErrorText;
    public Text[] Inputs;
    public GameObject MatchesPanel;
    public Text MatchNumberText;
    public Text CurrentMatchText;

    private int MatchNumber;

    public Data[] data;

    #region UNITY Functions
    void Awake()
    {
        MatchNumber = 0;

        data = new Data[6]; //Holds the latest Data for match

        Matches = new List<Match>();
    }

    void Update()
    {
        if (MatchesPanel.activeInHierarchy)
        {


            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Hard coded for simplicity
                if (Inputs[0].text.Equals("") || Inputs[1].text.Equals("") ||
                    Inputs[2].text.Equals("") || Inputs[3].text.Equals("") ||
                    Inputs[4].text.Equals("") || Inputs[5].text.Equals("") ||
                    MatchNumberText.text.Equals(""))
                {
                    ErrorText.text = "RE-ENTER TEAM NUMBERS OR MATCH NUMBEr";
                }
                else
                {
                    if (MatchNumber == 0)
                    {
                        MatchNumber = int.Parse(MatchNumberText.text.Trim());
                        Destroy(MatchNumberText.transform.parent.gameObject);
                    }
                    Debug.Log("Entered Match " + MatchNumber);
                    MatchNumber++;
                    CurrentMatchText.text = "Current Match : " + MatchNumber;
                }
            }
        }
    }
    #endregion

    public void EnterAutoData()
    {
        Scout[] scouts = FindObjectsOfType<Scout>();
        Scout[] ActiveScouts = new Scout[6];

        //Find all the active scouts
        int counter = 0;
        foreach(Scout s in scouts)
        {
            if(s.gameObject.activeInHierarchy)
            {
                ActiveScouts[counter] = s;
                counter++;
            }
        }
    }
}

public class Match
{
    //Probably shouldn't make these all public
    public int MatchNumber;
    public int Blue1, Blue2, Blue3;
    public int Red1, Red2, Red3;

    public Match(int match, int blue1, int blue2, int blue3,
        int red1, int red2, int red3)
    {
        MatchNumber = match;
        Blue1 = blue1;
        Blue2 = blue2;
        Blue3 = blue3;

        Red1 = red1;
        Red2 = red2;
        Red3 = red3;
    }
}

/// <summary>
/// Container Class to hold data for the latest match
/// </summary>
public class Data
{
    //Auto Variables
    public int AutoGears;
    public int AutoBalls;
    public bool AutoCross;

    //Tele Variables
    public int TeleGears;
    public float TeleShootingPercentage;
    public int TeleBalls;
    public bool TeleClimb;
    public bool MatchResult;

    public void EnterAutoData(int Gears, int Balls, bool Cross)
    {
        AutoGears = Gears;
        AutoBalls = Balls;
        AutoCross = Cross;
    }

    public void EneterTeleData(int Gears, float Percent, int Balls,
        bool Climb, bool Result)
    {
        TeleGears = Gears;
        TeleShootingPercentage = Percent;
        TeleBalls = Balls;
        TeleClimb = Climb;
        MatchResult = Result;
    }
}
