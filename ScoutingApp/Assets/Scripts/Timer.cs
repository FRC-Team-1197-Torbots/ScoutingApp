using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timeLeft;
    public Text time;
    public GameObject AutoPanel;
    public GameObject TelePanel;
    bool pressed;

    // Use this for initialization
    void Awake () {
        pressed = false;
	}

    // Update is called once per frame
    void Update()
    {
        
        double test = (int)(timeLeft * 10) / 10.0;
        time.GetComponent<Text>().text = test.ToString();
        if (pressed == true) { 
          if (timeLeft >= 0)
           {
              timeLeft -= Time.deltaTime;
              Debug.Log(timeLeft);
           }
          if (timeLeft < 0)
           {
              AutoPanel.SetActive(false);
              TelePanel.SetActive(true);
              FindObjectOfType<MatchInfo>().TransitionToTele();
           }
         }
    }

    
    public void startTimer()
    {
        pressed = true;
           
        
    }
}
