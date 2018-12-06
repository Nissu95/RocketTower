using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IamPlayer : MonoBehaviour {

	void Start () {
        PlayerManager.AddPlayer(this);
	}
    private void OnDestroy()
    {
        PlayerManager.RemovePlayer(this);
    }
}
