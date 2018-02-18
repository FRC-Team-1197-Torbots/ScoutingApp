using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour {

    private Scout[] scouts;
    private bool clearbutton;
    // Use this for initialization
    void Awake()
    {
        scouts = FindObjectsOfType<Scout>();
        clearbutton = false;
    }

    /// <summary>
    /// Functions clears all the fields and does not save
    /// </summary>
    
    
    public void clearbuttonClicked()
    {
        //clearbutton = true;
    }
    private void OnMouseDown()
    {
        clearbutton = true;
    }
    public void ClearFields()
    {
        if (clearbutton == true)
        {
            foreach(Scout s in scouts)
            {
                s.Clear();
            }
            clearbutton = false;
        }
            
    }
}
