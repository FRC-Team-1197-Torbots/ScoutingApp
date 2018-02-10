using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Presets_Script : MonoBehaviour {
    [Header("Presets")]
    public string Year;
    public Text YearText;
    public Text YearText2;
    public string Regional;
    public Text RegionalText;
    public Text RegionalText2;

    public Text InputRegional;
    public Text InputYear;

    private void Awake()
    {
        setPresets();
        
    }
    public void setNumbers()
    {
        Year = InputYear.text;
        //Year = Convert.ToInt32(YearText2.text);
        Regional = InputRegional.text;
        //Regional = Convert.ToInt32(RegionalText2.text);
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
