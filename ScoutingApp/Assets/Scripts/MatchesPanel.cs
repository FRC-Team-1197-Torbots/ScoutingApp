using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MatchesPanel : MonoBehaviour
{
    public string[] teamNums;
    public int matchNumber;

    public InputField[] TeamNumberTexts;

    // Use this for initialization
    public void inputTeamNum()
    {
        string teamNum;
    }


    void OnEnable()
    {
        foreach(InputField i in TeamNumberTexts)
        {
            //Debug.Log("On Enbled " + t.transform.parent.name);
            i.text = "";
        }
    }
}
