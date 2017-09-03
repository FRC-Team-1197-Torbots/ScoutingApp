using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAuto : MonoBehaviour {

    public GameObject MatchesPanel;
    public GameObject AutoPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        MatchesPanel.SetActive(false);
        AutoPanel.SetActive(true);
    }
}