using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Submit : MonoBehaviour {
    
    public Scout[] scouts;
    
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
    void Awake () {
        
    }
    public void OnClick()
    {
        Debug.Log("Pressed submit");
        scouts = FindObjectsOfType<Scout>();
        /* Connecting and opening the database
         * Name of the database = [Regional Name]ScoutingData.db
         */
        String conn = "URI=file:" + Application.dataPath + "/BeachBlitzScoutingData.db";
        Debug.Log(conn);
        dbconn = new SqliteConnection(conn);
        dbconn.Open();

        /* For each team, insert the data into the database
         * TELEOP table fields: (team#, match#, #ofCubesInSwitch, Cubes in Vault, #ofCubesInScale, Climb?, TeamResult)
         * AUTO table fields: (team#, match#, #ofGears, Baseline, #ofShots)
         * TODO: Change the *obtain info from the app* to the actual data
         *       Maybe check which panel is active to decide whether to put the data into the TELEOP or the AUTO table (?)
         */

        //for (int i = 0; i < 6; i++){
        //  scout s in scouts;
        //        scouts(i);
        //  }
        //change data to string
        String[] teamsData = new String[6];
        int i = 0;
        foreach (Scout s in scouts)
        {
            int match = s.id;
            

            int cubeSwitch = s.NumberOfCubesInSwitch + i;
            int cubeScale = s.NumberOfCubesInScale;
            int cubeVault = s.NumberOfCubesInVault;
            String outcome = "";
            String climbString = "";
            if (s.Result){
                outcome = "\"Win\"";
            } else{
                outcome = "\"Lost\"";
            }
            if (s.Climb)
            {
                climbString = "\"Yes\"";
            } else
            {
                climbString = "\"No\"";
            }
            String testing = i.ToString();
            teamsData[i] = "INSERT INTO TELEOP VALUES" + "(" + "null" + ", " + match.ToString() + ", " + cubeSwitch.ToString() + ", " + cubeVault.ToString() + ", " + cubeScale.ToString() + ", "  
                + climbString + ", " + outcome + ")";
            Debug.Log(teamsData[i]);
            i++;
        }
        Debug.Log("INSERT INTO TELEOP VALUES (" + teamsData[0] + " )");
        red1cmd = dbconn.CreateCommand();
        red1cmd.CommandText =  teamsData[0] ;
        red1cmd.ExecuteReader();

        red2cmd = dbconn.CreateCommand();
        red2cmd.CommandText =  teamsData[1] ;
        red2cmd.ExecuteReader();

        red3cmd = dbconn.CreateCommand();
        red3cmd.CommandText = teamsData[2] ;
        red3cmd.ExecuteReader();

        blue1cmd = dbconn.CreateCommand();
        blue1cmd.CommandText = teamsData[3] ;
        blue1cmd.ExecuteReader();

        blue2cmd = dbconn.CreateCommand();
        blue2cmd.CommandText = teamsData[4] ;
        blue2cmd.ExecuteReader();

        blue3cmd = dbconn.CreateCommand();
        blue3cmd.CommandText =  teamsData[5] ;
        blue3cmd.ExecuteReader();


        // dbcmd and reader is used for testing SQL queries
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = "SELECT * FROM TELEOP WHERE TEAM_NUM = 1114";
        reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            int teamNum = reader.GetInt32(0);
            int matchNum = reader.GetInt32(1);
            int gearNum = reader.GetInt32(2);
            int shotPerc = reader.GetInt32(3);
            int shotNum = reader.GetInt32(4);
            String climb = reader.GetString(5);
            String teamResult = reader.GetString(6);

            Debug.Log("Team Number: " + teamNum + "\n" +
                      "Match Number: " + matchNum + "\n" +
                      "# of Gears: " + gearNum + "\n" +
                      "Shot %: " + shotPerc + "\n" +
                      "# of Shots: " + shotNum + "\n" +
                      "Climb?: " + climb + "\n" +
                      "Team Result: " + teamResult + "\n");
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

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;

        // Disconnecting from the database
        dbconn.Close();
        dbconn = null;
    }
    /// <summary>
    /// Function to submit scores to the SQLite Database
    /// </summary>
    public void SubmitFields()
    {
        Debug.Log("HAISDOISAHDOIAHSOIHSAOIDSAHD");
        /* Connecting and opening the database
         * Name of the database = [Regional Name]ScoutingData.db
         */
        String conn = "URI=file:" + Application.dataPath + "/BeachBlitzScoutingData.db";
        dbconn = new SqliteConnection(conn);
        dbconn.Open();

        /* For each team, insert the data into the database
         * TELEOP table fields: (team#, match#, #ofGears, Shot%, #ofShots, Climb?, TeamResult)
         * AUTO table fields: (team#, match#, #ofGears, Baseline, #ofShots)
         * TODO: Change the *obtain info from the app* to the actual data
         *       Maybe check which panel is active to decide whether to put the data into the TELEOP or the AUTO table (?)
         */

        red1cmd = dbconn.CreateCommand();
        red1cmd.CommandText = "INSERT INTO TELEOP VALUES (" + "1197, 24, 3, 19, 33, \"Yes\", \"Win\"" + ")";
        red1cmd.ExecuteReader();

        red2cmd = dbconn.CreateCommand();
        red2cmd.CommandText = "INSERT INTO TELEOP VALUES (" + "1114, 23, 4, 59, \"No\", \"Win\"" + ")";
        red2cmd.ExecuteReader();

        red3cmd = dbconn.CreateCommand();
        red3cmd.CommandText = "INSERT INTO TELEOP VALUES (" + "1198, 28, 5, 94, \"Yes\", \"Lost\"" + ")";
        red3cmd.ExecuteReader();

        blue1cmd = dbconn.CreateCommand();
        blue1cmd.CommandText = "INSERT INTO TELEOP VALUES (" + "11, 29, 2, 13, \"Yes\", \"Tie\"" + ")";
        blue1cmd.ExecuteReader();

        blue2cmd = dbconn.CreateCommand();
        blue2cmd.CommandText = "INSERT INTO TELEOP VALUES (" + "4, 1, 0, 12, \"No\", \"Lost\"" + ")";
        blue2cmd.ExecuteReader();

        blue3cmd = dbconn.CreateCommand();
        blue3cmd.CommandText = "INSERT INTO TELEOP VALUES (" + "117, 234, 3, 19, \"Yes\", \"Lost\"" + ")";
        blue3cmd.ExecuteReader();


        // dbcmd and reader is used for testing SQL queries
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = "SELECT * FROM TELEOP WHERE TEAM_NUM = 1114";
        reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            int teamNum = reader.GetInt32(0);
            int matchNum = reader.GetInt32(1);
            int gearNum = reader.GetInt32(2);
            int shotPerc = reader.GetInt32(3);
            int shotNum = reader.GetInt32(4);
            String climb = reader.GetString(5);
            String teamResult = reader.GetString(6);

            Debug.Log("Team Number: " + teamNum + "\n" +
                      "Match Number: " + matchNum + "\n" +
                      "# of Gears: " + gearNum + "\n" +
                      "Shot %: " + shotPerc + "\n" +
                      "# of Shots: " + shotNum + "\n" +
                      "Climb?: " + climb + "\n" +
                      "Team Result: " + teamResult + "\n");
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

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;

        // Disconnecting from the database
        dbconn.Close();
        dbconn = null;

    }
    }

