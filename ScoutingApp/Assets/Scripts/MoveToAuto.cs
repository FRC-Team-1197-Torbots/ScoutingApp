using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAuto : MonoBehaviour {

    public GameObject MatchesPanel;
    public GameObject AutoPanel;
    

	// Use this for initialization
	void Awake () {
       
	}

    public void OnClick()
    {
        MatchesPanel.SetActive(false);
        AutoPanel.SetActive(true);
        FindObjectOfType<MatchInfo>().TransitionToAuto();
    }
}