using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public InputListener[] AllInputs;
    public static InputManager Singleton;
	// Use this for initialization
	void Awake () {
        AllInputs = GetComponents<InputListener>();
        Singleton = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
