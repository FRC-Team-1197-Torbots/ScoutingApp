using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidScript : MonoBehaviour {

    public float x;
    public AnimationCurve velocity;

	// Use this for initialization
	void Awake () {
        Debug.Log("This is a test");
        //Debug.Log(x);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, 0.001f);
        x = transform.position.y;
	}
}
