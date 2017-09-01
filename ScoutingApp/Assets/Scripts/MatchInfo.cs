using System.Collections;
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

    private int MatchNumber;

    void Awake()
    {
        MatchNumber = 0;
        MatchNumberText.text = "Match Number : " + MatchNumber;

        Matches = new List<Match>();
    }

    void Update()
    {
        if(MatchesPanel.activeInHierarchy)
        {
            MatchNumberText.text = "Match Number : " + MatchNumber;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Hard coded for simplicity
                if (Inputs[0].text.Equals("") || Inputs[1].text.Equals("") ||
                    Inputs[2].text.Equals("") || Inputs[3].text.Equals("") ||
                    Inputs[4].text.Equals("") || Inputs[5].text.Equals(""))
                {
                    ErrorText.text = "RE-ENTER TEAM NUMBERS";
                } else
                {
                    MatchNumber++;
                }
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
