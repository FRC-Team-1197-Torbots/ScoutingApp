using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Submit : MonoBehaviour
{


    public GameObject AutoPanel;
    public GameObject TelePanel;
    public GameObject InputPanel;

    public Scout[] AutoScouts;
    public Scout[] TeleScouts;

    // Connection object used to connect to the database
    private IDbConnection dbconn;

    // Command objects for each team to insert the data into the database
    private IDbCommand red1cmd;
    private IDbCommand red2cmd;
    private IDbCommand red3cmd;
    private IDbCommand blue1cmd;
    private IDbCommand blue2cmd;
    private IDbCommand blue3cmd;

    // Used for testing
    private IDbCommand dbcmd;
    private IDataReader reader;

    // Use this for initialization
    void Awake()
    {

    }


    public void OnClick()
    {
        /* Connecting and opening the database
         * Name of the database = [Year][Regional Name]ScoutingData.db
         */
        String conn = "URI=file:" + Application.dataPath + "/2018BeachBlitzScoutingData.db";
        dbconn = new SqliteConnection(conn);
        dbconn.Open();

        /* For each team, insert the data into the database
         * TELEOP table fields: (team#, match#, #ofCubesInSwitch, Cubes in Vault, #ofCubesInScale, Climb?, TeamResult)
         *                       int,    int,    int,                int,             int,          text,   text
         * AUTO table fields: (team#, match#, #ofCubesInSwitch, Baseline, #ofCubesInScale, #ofCubesInVault)
                               int,    int,    int,              text,      int
         * TODO: Change the *obtain info from the app* to the actual data
         *       Maybe check which panel is active to decide whether to put the data into the TELEOP or the AUTO table (?)
         */

        //change data to string
        String[] teleData = new String[6]; //teamsData holds command for input into SQL
        String[] autoData = new String[6]; //teamsData holds command for input into SQL
                                          

 //for loop to get data from each team for auto
        int j = 0;
        foreach (Scout s in AutoScouts)
        {
            int teamNum = s.NumberTeam;
            int match = s.MatchNumber;
            int ballsHigh = s.NumberOfBallsHigh;
            int ballsLow = s.NumberOfBallsLow;
            int ballsMid = s.NumberOfBallsMid;
            int hatchLow = s.NumberOfHatchLow;
            int hatchMid = s.NumberOfHatchMid;
            int hatchHigh = s.NumberOfHatchHigh;
            Boolean baseline = s.CrossBaseline;
            String baselineString = "\"Not passed\"";
            if (baseline)
                baselineString = "\"Passed\"";

 
            autoData[j] = "INSERT INTO AUTO VALUES" + "(" + teamNum.ToString() + ", " + match.ToString() + ", "
                    + ballsLow.ToString() + ", " + baselineString + ", " + ballsMid.ToString() + ", " + ballsHigh.ToString() + ", " +
                    hatchLow.ToString()  + ", " + hatchMid.ToString() + ", " + hatchHigh.ToString() + ", " + ")";
            j++;
            s.NumberTeam = 0;
        }

 //get data from teams in teleop period
        int i = 0;
        foreach (Scout s in TeleScouts)
        {
            int teamNum = s.NumberTeam;
            int match = s.MatchNumber;
            int ballsLow = s.NumberOfBallsLow;
            int ballsMid = s.NumberOfBallsMid;
            int ballsHigh = s.NumberOfBallsHigh;
            int hatchLow = s.NumberOfHatchLow;
            int hatchMid = s.NumberOfHatchMid;
            int hatchHigh = s.NumberOfHatchHigh;
            
            String climbString = "\"No\"";
            String quest = "\""+ s.quest + "\"";
                
            if (s.climb == 1)
            {
                climbString = "\"Plat\"";
            }
            else if (s.climb == 2)
            {
                climbString = "\"Lev 2\"";
            }
            else if(s.climb == 3)
            {
                climbString = "\"Lev 3\"";
            }

            teleData[i] = "INSERT INTO TELEOP VALUES" + "(" + teamNum + ", " + match.ToString() + ", "
                + ballsLow.ToString() + ", " + ballsHigh.ToString() + ", " + ballsMid.ToString() + ", " + hatchLow.ToString() + ", " +  
                hatchMid.ToString() + ", " + hatchHigh.ToString() + ", "+ climbString
                 + ", " + quest + ")";

            s.NumberTeam = 0;

            i++;

        }

       




        //red 1 auto data
        red1cmd = dbconn.CreateCommand();
        red1cmd.CommandText = autoData[0];
        red1cmd.ExecuteReader();
   
        //red 1 tele data
        red1cmd = dbconn.CreateCommand();
        red1cmd.CommandText = teleData[0];
        red1cmd.ExecuteReader();
   
        //red 2 auto data
        red2cmd = dbconn.CreateCommand();
        red2cmd.CommandText = autoData[1];
        red2cmd.ExecuteReader();
        //red 2 tele data 
        red2cmd = dbconn.CreateCommand();
        red2cmd.CommandText = teleData[1];
        red2cmd.ExecuteReader();
        //red 3 auto data
        red3cmd = dbconn.CreateCommand();
        red3cmd.CommandText = autoData[2];
        red3cmd.ExecuteReader();
        //red 3 teledata
        red3cmd = dbconn.CreateCommand();
        red3cmd.CommandText = teleData[2];
        red3cmd.ExecuteReader();
        //blue 1 auto data
        blue1cmd = dbconn.CreateCommand();
        blue1cmd.CommandText = autoData[3];
        blue1cmd.ExecuteReader();
        ///blue 1 tele data
        blue1cmd = dbconn.CreateCommand();
        blue1cmd.CommandText = teleData[3];
        blue1cmd.ExecuteReader();
        //blue 2 auto data
        blue2cmd = dbconn.CreateCommand();
        blue2cmd.CommandText = autoData[4];
        blue2cmd.ExecuteReader();
        //blue 2 tele data
        blue2cmd = dbconn.CreateCommand();
        blue2cmd.CommandText = teleData[4];
        blue2cmd.ExecuteReader();
        //blue 3 auto data
        blue3cmd = dbconn.CreateCommand();
        blue3cmd.CommandText = autoData[5];
        blue3cmd.ExecuteReader();
        //blue 3 tele data
        blue3cmd = dbconn.CreateCommand();
        blue3cmd.CommandText = teleData[5];
        blue3cmd.ExecuteReader();

        // dbcmd and reader is used for testing SQL queries

        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = "SELECT * FROM TELEOP WHERE TEAM_NUM = 1197";
        reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            int teamNum = reader.GetInt32(0);
            int matchNum = reader.GetInt32(1);
            int switchNum = reader.GetInt32(2);
            int vaultNum = reader.GetInt32(3);
            int scaleNum = reader.GetInt32(4);
            String climb = reader.GetString(5);
            //String teamResult = reader.GetString(6);

            Debug.Log("Team Number: " + teamNum + "\n" +
                      "Match Number: " + matchNum + "\n" +
                      "# of Cubes in Switch: " + switchNum + "\n" +
                      "# of Cubes in Vault: " + vaultNum + "\n" +
                      "# of Cubes in Scale: " + scaleNum + "\n" +
                      "Climb: " + climb + "\n");
        }


        // Closing and disposing the readers and the commands
        red1cmd.Dispose();
        red1cmd = null;
        red2cmd.Dispose();
        red2cmd = null;
        red3cmd.Dispose();
        red3cmd = null;
        blue1cmd.Dispose();
        blue1cmd = null;
        blue2cmd.Dispose();
        blue2cmd = null;
        blue3cmd.Dispose();
        blue3cmd = null;

        /*
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        */
        // Disconnecting from the database
        dbconn.Close();
        dbconn = null;

        TelePanel.SetActive(false);
        AutoPanel.SetActive(false);
        InputPanel.SetActive(true);
        FindObjectOfType<MatchInfo>().TransitionToPrematch();
    }
    /// <summary>
    /// Function to submit scores to the SQLite Database
    /// </summary>
    public void SubmitFields()
    {
        //moved to onClick

    }
}

