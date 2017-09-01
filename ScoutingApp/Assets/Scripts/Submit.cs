using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submit : MonoBehaviour {

    private Scout[] scouts;

	// Use this for initialization
	void Awake () {
        scouts = FindObjectsOfType<Scout>();
    }

    /// <summary>
    /// Function to submit scores to the SQLite Database
    /// </summary>
    public void SubmitFields()
    {
        Debug.Log("Submitting");
    }
}
