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
    public Text MatchNumberText;
    public Text CurrentMatchText;

    private int MatchNumber;
    private string[] AutoCats = { "# of Cubes in Switch", "Baseline Crossed", "# of Cubes in Scale"};
    private string[] TeleCats = { "# of Cubes in Switch", "# of Cubes in Vault", "# of Cubes in Scale",
                                    "Climb", "Team Result"};

    public Data[] data;
    private Scout[] scouts;

    [Header("Panels")]
    public GameObject MatchesPanel;
    public GameObject AutoPanel;

    public enum STATE
    {
        PREMATCH,AUTO,TELE
    };

    private STATE m_state;

    #region UNITY Functions
    void Awake()
    {
        m_state = STATE.PREMATCH;

        MatchNumber = 0;

        data = new Data[6]; //Holds the latest Data for match

        Matches = new List<Match>();

        scouts = FindObjectsOfType<Scout>();

        //Order scouts into red 1-3 blue 1-3
        #region Ordering
        Scout r1 = null, r2 = null, r3 = null, b1 = null, b2 = null, b3 = null;
        foreach(Scout s in scouts)
        {
            if(s.team == "Red")
            {
                if(s.id == 1)
                {
                    r1 = s;
                } else if(s.id == 2)
                {
                    r2 = s;
                } else
                {
                    r3 = s;
                }
            } else
            {
                if (s.id == 1)
                {
                    b1 = s;
                }
                else if (s.id == 2)
                {
                    b2 = s;
                }
                else
                {
                    b3 = s;
                }
            }
        }

        if(r1 && r2 && r3 && b1 && b2 && b3)
        {
            scouts[0] = r1;
            scouts[1] = r2;
            scouts[2] = r3;
            scouts[3] = b1;
            scouts[4] = b2;
            scouts[5] = b3;
        } else
        {
            Debug.LogError("One of the scouts is wrong");
        }
        

        #endregion
    }

    void Update()
    {
        #region Entering Matchs
        if (m_state == STATE.PREMATCH)
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
        #endregion

        #region Input
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
            scouts[0].NumberOfCubesInSwitch++;
            buttonPressed = true;
        }
        else if (Input.GetButton("Xbox_1_LB"))
        {
            scouts[0].NumberOfCubesInScale++;
            buttonPressed = true;
        }

        if (buttonPressed)
        {
            scouts[0].LightOn();
        }
        else
        {
            scouts[0].LightOff();
        }
        #endregion
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

    public void EnterData()
    {
        Debug.Log("Entering Data");
        foreach(Data d in data)
        {
            //TODO enter data to database here
            d.clear();
        }
    }

    public void TransitionToAuto()
    {
        MatchesPanel.SetActive(false);
        AutoPanel.SetActive(true);
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
    public int AutoSwitch;
    public int AutoScale;
    public bool AutoCross;

    //Tele Variables
    public int TeleSwitch;
    public int TeleVault;
    public int TeleScale;
    public bool TeleClimb;
    public bool MatchResult;
 
    public void clear()
    {
        AutoSwitch = 0;
        AutoScale = 0;
        AutoCross = false;

        TeleSwitch = 0;
        TeleVault = 0;
        TeleScale = 0;
        TeleClimb = false;
        MatchResult = false;
    }

    public void EnterAutoData(int switchCubes, int scaleCubes, bool Cross)
    {
        AutoSwitch = switchCubes;
        AutoScale = scaleCubes;
        AutoCross = Cross;
    }

    public void EnterTeleData(int switchCubes, int vaultCubes, int scaleCubes, bool Climb, bool Result)
    {
        TeleSwitch = switchCubes;
        TeleVault = vaultCubes;
        TeleScale = scaleCubes;
        TeleClimb = Climb;
        MatchResult = Result;
    }
}
