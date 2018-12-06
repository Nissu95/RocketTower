using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RemainingPlayerName : MonoBehaviour {
    Text t;
	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = PlayerManager.WinnerPlayerName();
	}
	
}
