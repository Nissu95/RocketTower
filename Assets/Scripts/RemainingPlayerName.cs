using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RemainingPlayerName : MonoBehaviour {

    Text t;

	void Start ()
    {
        GetComponent<Text>().text = PlayerManager.WinnerPlayerName() + " Score: " + PlayerManager.GetWinnerScore();
        PlayerManager.SetWinnerScore(0);
	}
	
}
