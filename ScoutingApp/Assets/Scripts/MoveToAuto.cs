﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAuto : MonoBehaviour {

    public GameObject MatchesPanel;
    public GameObject AutoPanel;
    public GameObject TelePanel;
	// Use this for initialization
	void Awake () {
       
	}

    public void matchesToAuto()
    {
        MatchesPanel.SetActive(false);
        AutoPanel.SetActive(true);
        FindObjectOfType<MatchInfo>().TransitionToAuto();
    }
    public void teleToAuto()
    {
        TelePanel.SetActive(false);
        AutoPanel.SetActive(true);
        FindObjectOfType<MatchInfo>().TransitionToAuto();
    }
}