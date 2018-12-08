using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IamPlayer : MonoBehaviour {

    public int score = 0;

	void Start ()
    {
        PlayerManager.AddPlayer(this);
	}

    private void OnDestroy()
    {
        PlayerManager.RemovePlayer(this);
    }
}
