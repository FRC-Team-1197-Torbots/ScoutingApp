using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Presets_Script : MonoBehaviour {
    [Header("Presets")]
    public int Year;
    public Text YearText;
    public Text YearText2;
    public int Regional;
    public Text RegionalText;
    public Text RegionalText2;
    private void Awake()
    {
        setPresets();
        
    }
    public void setPresets()
    {
        if (YearText)
        {
            YearText.text = "Year: " + Year.ToString();
        }
        if (YearText2)
        {
            YearText2.text = "Year: " + Year.ToString();
        }
        if (RegionalText)
        {
            RegionalText.text = "Regional: " + Regional.ToString();
        }
        if (RegionalText2)
        {
            RegionalText2.text = "Regional: " + Regional.ToString();
        }
    }
}
