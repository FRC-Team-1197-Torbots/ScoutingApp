using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour {

    private Scout[] scouts;

    // Use this for initialization
    void Awake()
    {
        scouts = FindObjectsOfType<Scout>();
    }

    /// <summary>
    /// Functions clears all the fields and does not save
    /// </summary>
    public void ClearFields()
    {
        foreach(Scout s in scouts)
        {
            s.Clear();
        }
    }
}
