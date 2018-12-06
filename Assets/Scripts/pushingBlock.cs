using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushingBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }
}
