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
    private string[] AutoCats = { "Number of Balls Low", "Number of Balls Mid", "Number of Balls High" };//changed this
    private string[] TeleCats = { "# of Cubes in Switch", "# of Cubes in Vault", "# of Cubes in Scale",
                                    "Climb", "Team Result"};

    public Data[] data;
    public Scout[] AutoScouts;
    public Scout[] TeleScouts;
    [Header("Notes")]
    public InputField[] ScoutNotes;

    [Header("Panels")]
    public GameObject MatchesPanel;
    public GameObject AutoPanel;

    //Subtraction Keys
    bool rt1Auto = false;
    bool rt1Tele = false;
    bool rt2Auto = false;
    bool rt2Tele = false;
    bool rt3Auto = false;
    bool rt3Tele = false;
    bool rt4Auto = false;
    bool rt4Tele = false;
    bool rt5Auto = false;
    bool rt5Tele = false;
    bool rt6Auto = false;
    bool rt6Tele = false;
    //LT keys
    bool lt1Auto = false;
    bool lt1Tele = false;
    bool lt2Auto = false;
    bool lt2Tele = false;
    bool lt3Auto = false;
    bool lt3Tele = false;
    bool lt4Auto = false;
    bool lt4Tele = false;
    bool lt5Auto = false;
    bool lt5Tele = false;
    bool lt6Auto = false;
    bool lt6Tele = false;
    public enum STATE
    {
        PREMATCH, AUTO, TELE
    };

    private STATE m_state;

    #region UNITY Functions
    void Awake()
    {
        m_state = STATE.PREMATCH;

        MatchNumber = 0;

        data = new Data[6]; //Holds the latest Data for match

        Matches = new List<Match>();

        //AutoScoutsscouts = FindObjectsOfType<Scout>();


        //Order scouts into red 1-3 blue 1-3
        #region Ordering
        Scout r1 = null, r2 = null, r3 = null, b1 = null, b2 = null, b3 = null;
        foreach (Scout s in AutoScouts)
        {
            if (s.team == "Red")
            {
                if (s.id == 1)
                {
                    r1 = s;
                } else if (s.id == 2)
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

        if (r1 && r2 && r3 && b1 && b2 && b3)
        {
            AutoScouts[0] = r1;
            AutoScouts[1] = r2;
            AutoScouts[2] = r3;
            AutoScouts[3] = b1;
            AutoScouts[4] = b2;
            AutoScouts[5] = b3;
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
                    ErrorText.text = "RE-ENTER TEAM NUMBERS OR MATCH NUMBER";
                }
                else
                {
                    if (MatchNumber == 0)
                    {
                        MatchNumber = int.Parse(MatchNumberText.text.Trim());
                        //Destroy(MatchNumberText.transform.parent.gameObject);
                    }
                    Debug.Log("Entered Match " + MatchNumber);
                    MatchNumber++;
                    CurrentMatchText.text = "Current Match : " + MatchNumber;
                }
            }
        }
        #endregion
        //reset whenever it returns to prematch
        if (m_state == STATE.PREMATCH)
        {
            foreach (Scout s in AutoScouts)
            {
                s.NumberOfBallsLow = 0;
                s.NumberOfBallsMid = 0;
                s.NumberOfBallsHigh = 0;
                s.Climb = false;
                s.CrossBaseline = false;
                s.Result = false;
                s.quest = "";
            }
            foreach (Scout s in TeleScouts)
            {
                s.NumberOfBallsLow = 0;
                s.NumberOfBallsMid = 0;
                s.NumberOfBallsHigh = 0;
                s.Climb = false;
                s.CrossBaseline = false;
                s.Result = false;
                s.quest = "";
            }
            foreach (InputField t in ScoutNotes)
            {
                t.text = "";
            }
        }
        #region Input
        if (m_state == STATE.AUTO) {
            //AUTO
            //controller 1     
            bool buttonPressed = false;

            if (Input.GetButtonUp("Xbox_1_A"))
            {
                AutoScouts[0].NumberOfBallsLow++;
                buttonPressed = true;
                //  AutoScouts[0].CrossBaseline = true;
            }
            else if (Input.GetButtonUp("Xbox_1_B"))
            {
                AutoScouts[0].NumberOfBallsHigh++;
                buttonPressed = true;
            }
            else if (Input.GetButtonUp("Xbox_1_X"))
            {
                AutoScouts[0].NumberOfBallsMid++;
                buttonPressed = true;
            }
            else if (Input.GetButtonUp("Xbox_1_Y"))
            {
                AutoScouts[0].NumberOfBallsHigh++;
                buttonPressed = true;
            }
            else if (Input.GetButtonUp("Xbox_1_RB"))
            {
                //AutoScouts[0].NumberOfBallsLow++;
                buttonPressed = true;
            }
            else if (Input.GetButtonUp("Xbox_1_LB"))
            {
                //AutoScouts[0].NumberOfCubesInScale++;
                buttonPressed = true;
            }
            if (Input.GetAxis("Xbox_1_RT") == 1)
            {
                // AutoScouts[0].NumberOfBallsMid++;
                buttonPressed = true;
            }
            if (Input.GetAxis("Xbox_1_LT") == 0)
            {
                lt1Auto = false;
            }
            else if (Input.GetAxis("Xbox_1_LT") == 1)
            {
                buttonPressed = true;
                /*   if (lt1Auto == false && AutoScouts[0].NumberOfCubesInScale > 0)
                   {
                       AutoScouts[0].NumberOfCubesInScale--;
                       lt1Auto = true;
                   }*/
            }
            if (buttonPressed)
            {
                AutoScouts[0].LightOn();
            }
            else
            {
                AutoScouts[0].LightOff();
            }
   //controller 2
            bool buttonPressed2 = false;
            if (Input.GetButtonUp("Xbox_2_A"))
            {
                AutoScouts[1].NumberOfBallsLow++;
                buttonPressed2 = true;
            }
            else if (Input.GetButtonUp("Xbox_2_B"))
            {
                //AutoScouts[1].NumberOfBallsHigh++;
                buttonPressed2 = true;
            }
            else if (Input.GetButtonUp("Xbox_2_X"))
            {
                AutoScouts[1].NumberOfBallsMid++;
                buttonPressed2 = true;
            }
            else if (Input.GetButtonUp("Xbox_2_Y"))
            {
                AutoScouts[1].NumberOfBallsHigh++;
                buttonPressed2 = true;
            }
            else if (Input.GetButtonUp("Xbox_2_RB"))
            {
                //AutoScouts[1].NumberOfBallsLow++;
                buttonPressed2 = true;
            }
            else if (Input.GetButtonUp("Xbox_2_LB"))
            {
                //AutoScouts[1].NumberOfCubesInScale++;
                buttonPressed2 = true;
            }
            if (Input.GetAxis("Xbox_2_RT") == 1)
            {
                //AutoScouts[1].NumberOfBallsMid++;
                buttonPressed2 = true;
            }
                if (Input.GetAxis("Xbox_2_LT") == 0)
                {
                    lt2Auto = false;
                }
                else if (Input.GetAxis("Xbox_2_LT") == 1)
                {
                    buttonPressed2 = true;
                    /* if (lt2Auto == false && AutoScouts[1].NumberOfCubesInScale > 0)
                     {
                         AutoScouts[1].NumberOfCubesInScale--;
                         lt2Auto = true;
                     } */
                }
                if (buttonPressed2)
                {
                    AutoScouts[1].LightOn();
                }
                else
                {
                    AutoScouts[1].LightOff();
                }

   //controller 3
                bool buttonPressed3 = false;
                if (Input.GetButtonUp("Xbox_3_A"))
                {
                    AutoScouts[2].NumberOfBallsLow++;
                    buttonPressed3 = true;
                }
                else if (Input.GetButtonUp("Xbox_3_B"))
                {
                    //AutoScouts[2].Cross
                    // buttonPressed3 = true;
                }
                else if (Input.GetButtonUp("Xbox_3_X"))
                {
                    AutoScouts[2].NumberOfBallsMid++;
                    buttonPressed3 = true;
                }
                else if (Input.GetButtonUp("Xbox_3_Y"))
                {
                    AutoScouts[2].NumberOfBallsHigh++;
                    buttonPressed3 = true;
                }
                else if (Input.GetButtonUp("Xbox_3_RB"))
                {
                    //AutoScouts[2].NumberOfCubesInSwitch++;
                    //buttonPressed3 = true;
                }
                else if (Input.GetButtonUp("Xbox_3_LB"))
                {
                    //AutoScouts[2].NumberOfCubesInScale++;
                    //buttonPressed3 = true;
                }
                if (Input.GetAxis("Xbox_3_RT") == 0)
                {
                    //rt3Auto = false;
                }
                else if (Input.GetAxis("Xbox_3_RT") == 1)
                {
                    buttonPressed3 = true;
                    /*if (rt3Auto == false && AutoScouts[2].NumberOfCubesInSwitch > 0)
                    {
                        AutoScouts[2].NumberOfCubesInSwitch--;
                        rt3Auto = true;
                    }*/
                }
                if (Input.GetAxis("Xbox_3_LT") == 0)
                {
                    lt3Auto = false;
                }
                else if (Input.GetAxis("Xbox_3_LT") == 1)
                {
                    buttonPressed3 = true;
                    /* if (lt3Auto == false && AutoScouts[2].NumberOfCubesInScale > 0)
                     {
                         AutoScouts[2].NumberOfCubesInScale--;
                         lt3Auto = true;
                     }*/
                }
                if (buttonPressed3)
                {
                    AutoScouts[2].LightOn();
                }
                else
                {
                    AutoScouts[2].LightOff();
                }

    // controller 4
                bool buttonPressed4 = false;
                if (Input.GetButtonUp("Xbox_4_A"))
                {
                    AutoScouts[3].NumberOfBallsLow++;
                    buttonPressed4 = true;
                }
                else if (Input.GetButtonUp("Xbox_4_B"))
                {
                    //AutoScouts[3].CrossBaseline = false;
                    //buttonPressed4 = true;
                }
                else if (Input.GetButtonUp("Xbox_4_X"))
                {
                    AutoScouts[3].NumberOfBallsMid++;
                    buttonPressed4 = true;
                }
                else if (Input.GetButtonUp("Xbox_4_Y"))
                {
                    AutoScouts[3].NumberOfBallsHigh++;
                    buttonPressed4 = true;
                }
                else if (Input.GetButtonUp("Xbox_4_RB"))
                {
                    //AutoScouts[3].NumberOfCubesInSwitch++;
                    //buttonPressed4 = true;
                }
                else if (Input.GetButtonUp("Xbox_4_LB"))
                {
                    //AutoScouts[3].NumberOfCubesInScale++;
                    //buttonPressed4 = true;
                }
                if (Input.GetAxis("Xbox_4_RT") == 0)
                {
                    rt4Auto = false;

                }
                else if (Input.GetAxis("Xbox_4_RT") == 1)
                {
                    buttonPressed4 = true;
                    /* if (rt4Auto == false && AutoScouts[3].NumberOfCubesInSwitch > 0)
                     {
                         AutoScouts[3].NumberOfCubesInSwitch--;
                         rt4Auto = true;
                     }*/
                }
                if (Input.GetAxis("Xbox_4_LT") == 0)
                {
                    lt4Auto = false;
                }
                else if (Input.GetAxis("Xbox_4_LT") == 1)
                {
                    buttonPressed4 = true;
                    /*if (lt4Auto == false && AutoScouts[3].NumberOfCubesInScale > 0)
                    {
                        AutoScouts[3].NumberOfCubesInScale--;
                        lt4Auto = true;
                    }*/
                }
                if (buttonPressed4)
                {
                    AutoScouts[3].LightOn();
                }
                else
                {
                    AutoScouts[3].LightOff();
                }

    //controller 5
                bool buttonPressed5 = false;
                if (Input.GetButtonUp("Xbox_5_A"))
                {
                    AutoScouts[4].NumberOfBallsLow++;
                    buttonPressed5 = true;
                }
                else if (Input.GetButtonUp("Xbox_5_B"))
                {
                    //AutoScouts[4].CrossBaseline = false;
                    buttonPressed5 = true;
                }
                else if (Input.GetButtonUp("Xbox_5_X"))
                {
                    AutoScouts[4].NumberOfBallsMid++;
                    buttonPressed5 = true;
                }
                else if (Input.GetButtonUp("Xbox_5_Y"))
                {
                    AutoScouts[4].NumberOfBallsHigh++;
                    buttonPressed5 = true;
                }
                else if (Input.GetButtonUp("Xbox_5_RB"))
                {
                    //AutoScouts[4].NumberOfCubesInSwitch++;
                    buttonPressed5 = true;
                }
                else if (Input.GetButtonUp("Xbox_5_LB"))
                {
                    //AutoScouts[4].NumberOfCubesInScale++;
                    buttonPressed5 = true;
                }
                if (Input.GetAxis("Xbox_5_RT") == 0)
                {
                    rt5Auto = false;

                }
                else if (Input.GetAxis("Xbox_5_RT") == 1)
                {
                    buttonPressed5 = true;
                    /* if (rt5Auto == false && AutoScouts[4].NumberOfCubesInSwitch > 0)
                     {
                         AutoScouts[4].NumberOfCubesInSwitch--;
                         rt5Auto = true;
                     }*/
                }
                if (Input.GetAxis("Xbox_5_LT") == 0)
                {
                    lt5Auto = false;
                }
                else if (Input.GetAxis("Xbox_5_LT") == 1)
                {
                    buttonPressed5 = true;
                    /*if (lt5Auto == false && AutoScouts[4].NumberOfCubesInScale > 0)
                    {
                        AutoScouts[4].NumberOfCubesInScale--;
                        lt5Auto = true;
                    }*/
                }
                if (buttonPressed5)
                {
                    AutoScouts[4].LightOn();
                }
                else
                {
                    AutoScouts[4].LightOff();
                }

    //controller 6
                bool buttonPressed6 = false;
                if (Input.GetButtonUp("Xbox_6_A"))
                {
                    AutoScouts[5].NumberOfBallsLow++;
                    buttonPressed6 = true;
                }
                else if (Input.GetButtonUp("Xbox_6_B"))
                {
                    //AutoScouts[5].CrossBaseline = false;
                    buttonPressed6 = true;
                }
                else if (Input.GetButtonUp("Xbox_6_X"))
                {
                    AutoScouts[5].NumberOfBallsMid++;
                    buttonPressed6 = true;
                }
                else if (Input.GetButtonUp("Xbox_6_Y"))
                {
                    AutoScouts[5].NumberOfBallsHigh++;
                    buttonPressed6 = true;
                }
                else if (Input.GetButtonUp("Xbox_6_RB"))
                {
                    // AutoScouts[5].NumberOfCubesInSwitch++;
                    buttonPressed6 = true;
                }
                else if (Input.GetButtonUp("Xbox_6_LB"))
                {
                    //AutoScouts[5].NumberOfCubesInScale++;
                    buttonPressed6 = true;
                }
                if (Input.GetAxis("Xbox_6_RT") == 0)
                {
                    rt6Auto = false;

                }
                else if (Input.GetAxis("Xbox_6_RT") == 1)
                {
                    buttonPressed6 = true;
                    /* if (rt6Auto == false && AutoScouts[5].NumberOfCubesInSwitch > 0)
                     {
                         AutoScouts[5].NumberOfCubesInSwitch--;
                         rt6Auto = true;
                     }*/
                }
                if (Input.GetAxis("Xbox_6_LT") == 0)
                {
                    lt6Auto = false;
                }
                else if (Input.GetAxis("Xbox_6_LT") == 1)
                {
                    buttonPressed6 = true;
                    /*if (lt6Auto == false && AutoScouts[5].NumberOfCubesInScale > 0)
                    {
                        AutoScouts[5].NumberOfCubesInScale--;

                        lt6Auto = true;
                    }*/
                }
                if (buttonPressed6)
                {
                    AutoScouts[5].LightOn();
                }
                else
                {
                    AutoScouts[5].LightOff();
                }
            }
            else if (m_state == STATE.TELE)
            {
     //TELE
     //controller 1
                 bool buttonPressed = false;
               //buttonPressed = false;

                if (Input.GetButtonUp("Xbox_1_A"))
                {
                    TeleScouts[0].NumberOfBallsLow++;
                    buttonPressed = true;
                }
                else if (Input.GetButtonUp("Xbox_1_B"))
                {
                    TeleScouts[0].NumberOfBallsHigh++;
                    buttonPressed = true;
                }
                else if (Input.GetButtonUp("Xbox_1_X"))
                {
                    TeleScouts[0].NumberOfBallsMid++;
                    buttonPressed = true;
                }
                else if (Input.GetButtonUp("Xbox_1_Y"))
                {
                    TeleScouts[0].NumberOfBallsHigh++;
                    buttonPressed = true;
                }
                else if (Input.GetButtonUp("Xbox_1_RB"))
                {
                    //TeleScouts[0].NumberOfBallsLow++;
                    buttonPressed = true;
                }
                else if (Input.GetButtonUp("Xbox_1_LB"))
                {
                    //TeleScouts[0].NumberOfCubesInScale++;
                    buttonPressed = true;
                }
                if (Input.GetAxis("Xbox_1_RT") == 1)
                {
                    //TeleScouts[0].NumberOfBallsMid++;
                    buttonPressed = true;
                }
                if (Input.GetAxis("Xbox_1_LT") == 0)
                {
                    lt1Tele = false;
                }
                else if (Input.GetAxis("Xbox_1_LT") == 1)
                {
                    buttonPressed = true;

                    /* if (lt1Tele == false && TeleScouts[0].NumberOfCubesInScale > 0)
                     {
                         TeleScouts[0].NumberOfCubesInScale--;

                         lt1Tele = true;
                     }*/
                }
                if (buttonPressed)
                {
                    TeleScouts[0].LightOn();
                }
                else
                {
                    TeleScouts[0].LightOff();
                }

   //controller 2
                bool buttonPressed2 = false;
                //buttonPressed2 = false;

                if (Input.GetButtonUp("Xbox_2_A"))
                {
                    TeleScouts[1].NumberOfBallsLow++;
                    buttonPressed2 = true;
                }
                else if (Input.GetButtonUp("Xbox_2_B"))
                {
                    // TeleScouts[0].NumberOfBallsHigh++;
                    buttonPressed2 = true;
                }
                else if (Input.GetButtonUp("Xbox_2_X"))
                {
                    TeleScouts[1].NumberOfBallsMid++;
                    buttonPressed2 = true;
                }
                else if (Input.GetButtonUp("Xbox_2_Y"))
                {
                    TeleScouts[1].NumberOfBallsHigh++;
                    buttonPressed2 = true;
                }
                else if (Input.GetButtonUp("Xbox_2_RB"))
                {
                    //TeleScouts[1].NumberOfBallsLow++;
                    buttonPressed2 = true;
                }
                else if (Input.GetButtonUp("Xbox_2_LB"))
                {
                    //TeleScouts[1].NumberOfCubesInScale++;
                    buttonPressed2 = true;
                }
                if (Input.GetAxis("Xbox_2_RT") == 1)
                {
                    //TeleScouts[1].NumberOfBallsMid++;
                    //buttonPressed2 = true;
                }
                if (Input.GetAxis("Xbox_2_LT") == 0)
                {
                    lt2Tele = false;
                }
                else if (Input.GetAxis("Xbox_2_LT") == 1)
                {
                    buttonPressed2 = true;
                    /* if (lt2Tele == false && TeleScouts[1].NumberOfCubesInScale > 0)
                     {
                         TeleScouts[1].NumberOfCubesInScale--;

                         lt2Tele = true;
                     }*/
                }

                if (buttonPressed2)
                {
                    TeleScouts[1].LightOn();
                }
                else
                {
                    TeleScouts[1].LightOff();
                }

   //controller 3
                bool buttonPressed3 = false;

                if (Input.GetButtonUp("Xbox_3_A"))
                {
                    TeleScouts[2].NumberOfBallsLow++;
                    buttonPressed3 = true;
                }
                else if (Input.GetButtonUp("Xbox_3_B"))
                {
                    //TeleScouts[2].NumberOfBallsHigh++;
                    buttonPressed3 = true;
                }
                else if (Input.GetButtonUp("Xbox_3_X"))
                {
                    TeleScouts[2].NumberOfBallsMid++;
                    buttonPressed3 = true;
                }
                else if (Input.GetButtonUp("Xbox_3_Y"))
                {
                    TeleScouts[2].NumberOfBallsHigh++;
                    buttonPressed3 = true;
                }
                else if (Input.GetButtonUp("Xbox_3_RB"))
                {
                    //TeleScouts[2].NumberOfBallsLow++;
                    buttonPressed3 = true;
                }
                else if (Input.GetButtonUp("Xbox_3_LB"))
                {
                    //TeleScouts[2].NumberOfCubesInScale++;
                    buttonPressed3 = true;
                }
                if (Input.GetAxis("Xbox_3_RT") == 1)
                {
                    //TeleScouts[2].NumberOfBallsMid++;
                    buttonPressed2 = true;
                }
                if (Input.GetAxis("Xbox_3_LT") == 0)
                {
                    lt3Tele = false;
                }
                else if (Input.GetAxis("Xbox_3_LT") == 1)
                {
                    buttonPressed3 = true;
                    /* if (lt3Tele == false && TeleScouts[2].NumberOfCubesInScale > 0)
                     {
                         TeleScouts[2].NumberOfCubesInScale--;

                         lt3Tele = true;
                     }*/
                }
                if (buttonPressed3)
                {
                    TeleScouts[2].LightOn();
                }
                else
                {
                    TeleScouts[2].LightOff();
                }

    //controller 4
                bool buttonPressed4 = false;

                if (Input.GetButtonUp("Xbox_4_A"))
                {
                    TeleScouts[3].NumberOfBallsLow++;
                    buttonPressed4 = true;
                }
                else if (Input.GetButtonUp("Xbox_4_B"))
                {
                    //TeleScouts[3].NumberOfBallsHigh++;
                    buttonPressed4 = true;
                }
                else if (Input.GetButtonUp("Xbox_4_X"))
                {
                    TeleScouts[3].NumberOfBallsMid++;
                    buttonPressed4 = true;
                }
                else if (Input.GetButtonUp("Xbox_4_Y"))
                {
                    TeleScouts[3].NumberOfBallsHigh++;
                    buttonPressed4 = true;
                }
                else if (Input.GetButtonUp("Xbox_4_RB"))
                {
                    // TeleScouts[3].NumberOfBallsLow++;
                    buttonPressed4 = true;
                }
                else if (Input.GetButtonUp("Xbox_4_LB"))
                {
                    // TeleScouts[3].NumberOfCubesInScale++;
                    buttonPressed4 = true;
                }
                if (Input.GetAxis("Xbox_4_RT") == 1)
                {
                    //TeleScouts[3].NumberOfBallsMid++;
                    buttonPressed4 = true;
                }
                if (Input.GetAxis("Xbox_4_LT") == 0)
                {
                    lt4Tele = false;
                }
                else if (Input.GetAxis("Xbox_4_LT") == 1)
                {
                    buttonPressed4 = true;
                    /* if (lt4Tele == false && TeleScouts[3].NumberOfCubesInScale > 0)
                     {
                         TeleScouts[3].NumberOfCubesInScale--;                  
                         lt4Tele = true;
                     }*/
                }
                if (buttonPressed4)
                {
                    TeleScouts[3].LightOn();
                }
                else
                {
                    TeleScouts[3].LightOff();
                }

    //controller 5
                bool buttonPressed5 = false;

                if (Input.GetButtonUp("Xbox_5_A"))
                {
                    TeleScouts[4].NumberOfBallsLow++;
                    buttonPressed5 = true;
                }
                else if (Input.GetButtonUp("Xbox_5_B"))
                {
                    //TeleScouts[4].NumberOfBallsHigh++;
                    buttonPressed5 = true;
                }
                else if (Input.GetButtonUp("Xbox_5_X"))
                {
                    TeleScouts[4].NumberOfBallsMid++;
                    buttonPressed5 = true;
                }
                else if (Input.GetButtonUp("Xbox_5_Y"))
                {
                    TeleScouts[4].NumberOfBallsHigh++;
                    buttonPressed5 = true;
                }
                else if (Input.GetButtonUp("Xbox_5_RB"))
                {
                    //TeleScouts[4].NumberOfCubesInSwitch++;
                    buttonPressed5 = true;
                }
                else if (Input.GetButtonUp("Xbox_5_LB"))
                {
                    //TeleScouts[4].NumberOfCubesInScale++;
                    buttonPressed5 = true;
                }
                if (Input.GetAxis("Xbox_5_RT") == 1)
                {
                    // TeleScouts[4].NumberOfBallsMid++;
                    buttonPressed5 = true;
                }
                if (Input.GetAxis("Xbox_5_LT") == 0)
                {
                    lt5Tele = false;
                }
                else if (Input.GetAxis("Xbox_5_LT") == 1)
                {

                }
                if (buttonPressed5)
                {
                    TeleScouts[4].LightOn();
                }
                else
                {
                    TeleScouts[4].LightOff();
                }

     //controller 6
                bool buttonPressed6 = false;

                if (Input.GetButtonUp("Xbox_6_A"))
                {
                    TeleScouts[5].NumberOfBallsLow++;
                    buttonPressed6 = true;
                }
                else if (Input.GetButtonUp("Xbox_6_B"))
                {
                    // TeleScouts[5].NumberOfBallsHigh++;
                    buttonPressed6 = true;
                }
                else if (Input.GetButtonUp("Xbox_6_X"))
                {
                    TeleScouts[5].NumberOfBallsMid++;
                    buttonPressed6 = true;
                }
                else if (Input.GetButtonUp("Xbox_6_Y"))
                {
                    TeleScouts[5].NumberOfBallsHigh++;
                    buttonPressed6 = true;
                }
                else if (Input.GetButtonUp("Xbox_6_RB"))
                {
                    //TeleScouts[5].NumberOfBallsLow++;
                    buttonPressed6 = true;
                }
                else if (Input.GetButtonUp("Xbox_6_LB"))
                {
                    // TeleScouts[5].NumberOfCubesInScale++;
                    buttonPressed6 = true;
                }
                if (Input.GetAxis("Xbox_6_RT") == 0)
                {
                    rt6Tele = false;
                }
                else if (Input.GetAxis("Xbox_6_RT") == 1)
                {
                    //TeleScouts[5].NumberOfBallsMid++;
                    buttonPressed6 = true;
                }
                if (Input.GetAxis("Xbox_6_LT") == 0)
                {
                    lt6Tele = false;
                }
                else if (Input.GetAxis("Xbox_6_LT") == 1)
                {
                    buttonPressed6 = true;
                    /*  if (lt6Tele == false && TeleScouts[5].NumberOfCubesInScale > 0)
                      {
                          TeleScouts[5].NumberOfCubesInScale--;

                          lt6Tele = true;
                      }*/
                }
                if (buttonPressed6)
                {
                    TeleScouts[5].LightOn();
                }
                else
                {
                    TeleScouts[5].LightOff();
                }
            }

            #endregion
        }
        #endregion

        #region Enter Data

        public void EnterAutoData()
        {
            Scout[] scouts = FindObjectsOfType<Scout>();
            Scout[] ActiveScouts = new Scout[6];

            //Find all the active scouts
            int counter = 0;
            foreach (Scout s in scouts)
            {
                if (s.gameObject.activeInHierarchy)
                {
                    ActiveScouts[counter] = s;
                    counter++;
                }
            }
        }

        public void EnterData()
        {
            Debug.Log("Entering Data");
            foreach (Data d in data)
            {
                //TODO enter data to database here
                d.clear();
            }
        }

        public void TransitionToPrematch()
        {
            m_state = STATE.PREMATCH;
        }

        public void TransitionToAuto()
        {
            m_state = STATE.AUTO;
        }

        public void TransitionToTele()
        {
            m_state = STATE.TELE;
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
            Debug.Log("At clear");
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

#endregion