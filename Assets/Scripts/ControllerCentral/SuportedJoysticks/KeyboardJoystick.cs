using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardJoystick : PlayerJoystick {

    public override bool ListenCustom()
    {
        //Debug.Log("Listening for Keyboard");
        return false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
