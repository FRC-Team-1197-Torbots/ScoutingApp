using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAuto : MonoBehaviour {

    
    private MatchInfo info;

	// Use this for initialization
	void Awake () {
        info = FindObjectOfType<MatchInfo>();
	}

    public void OnClick()
    {
        info.TransitionToAuto();
        //MatchesPanel.SetActive(false);
        //AutoPanel.SetActive(true);
    }
}