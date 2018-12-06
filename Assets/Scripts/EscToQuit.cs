using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscToQuit : MonoBehaviour {
    
    [SerializeField] private GameObject quitCanvas;

	void Update () {

        if (Input.GetKey(KeyCode.Escape))
            quitCanvas.SetActive(true);

    }
}
