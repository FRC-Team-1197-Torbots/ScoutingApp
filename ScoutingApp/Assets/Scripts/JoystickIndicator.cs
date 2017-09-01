using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickIndicator : MonoBehaviour {

    private Image image;
    
    void Awake()
    {
        image = GetComponent<Image>();
        image.color = Color.yellow;
    }

	public void LightOn()
    {
        if(image != null)
        {
            image.color = Color.green;
        }        
    }

    public void LightOff()
    {
        if(image != null)
        {
            image.color = Color.yellow;
        }        
    }
}
