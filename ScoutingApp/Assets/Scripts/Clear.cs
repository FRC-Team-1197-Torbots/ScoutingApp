using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour {

    private Scout[] scouts;
    public Scout red1;
    public Scout red2;
    public Scout red3;
    public Scout blue1;
    public Scout blue2;
    public Scout blue3;
    public Scout theScout;
    private bool clearbutton;
    // Use this for initialization
    void Awake()
    {

    }

    /// <summary>
    /// Functions clears all the fields and does not save
    /// </summary>
    
    
    public void ClearFields()
    {
        Debug.Log("Going to clear fields");

            red1.Clear();
            red2.Clear();
            red3.Clear();
            blue1.Clear();
            blue2.Clear();
            blue3.Clear();
        
            
    }
    public void DidClearFields()
    {
        Debug.Log("Did Going to clear fields");

        red1.didClear();
        red2.didClear();
        red3.didClear();
        blue1.didClear();
        blue2.didClear();
        blue3.didClear();


    }
    public void clearOne()
    {
        theScout.Clear();
    }
}
