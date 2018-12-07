using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorPositionOnInput : MonoBehaviour {
    Vector2 pos;
    Vector2 scale;
    ActorPlayer ap;
    //SpriteRenderer r;

	// Use this for initialization
	void Awake () {
        ap = GetComponentInParent<ActorPlayer>();
        pos = transform.localPosition;
        scale = transform.localScale;
        //r = GetComponent<SpriteRenderer>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //r.flipX = ap.input.facingDirection<0;
        transform.localScale = new Vector2( scale.x * ap.input.facingDirection, scale.y);
        transform.position = (Vector2) transform.parent.position + new Vector2(pos.x * ap.input.facingDirection, pos.y);
    }
}
