using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public InputListener[] AllInputs;
    public static InputManager Singleton;

	void Awake () {
        DontDestroyOnLoad(this);
        AllInputs = GetComponents<InputListener>();

        if (Singleton != null)
            Destroy(gameObject);
        else
            Singleton = this;
    }
}
