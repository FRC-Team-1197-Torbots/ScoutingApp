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
        timeLeft = 15;
        pressed = false;
	}

    // Update is called once per frame
    void Update()
    {
        //Convert timeLeft so that it shows up with 1 decimal
        double test = (int)(timeLeft * 10) / 10.0;
        time.GetComponent<Text>().text = test.ToString();

        if (pressed == true) { 
          if (timeLeft >= 0) 
           {
              timeLeft -= Time.deltaTime;
           }
          if (timeLeft < 0) //switch to tele panel when time goes down to 0
           {
              AutoPanel.SetActive(false);
              TelePanel.SetActive(true);
              FindObjectOfType<MatchInfo>().TransitionToTele();
              timeLeft = 15;
              pressed = false;
           }
         }
    }

    
    public void startTimer()
    {
        pressed = true;
    }

    public void stopTimer()
    {
        pressed = false;
        timeLeft = 15;
    }
}
