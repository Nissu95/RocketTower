using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxJoystick : PlayerJoystick
{
    public override bool ListenCustom()
    {
        //Debug.Log("Listening for Xbox");
        return false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
