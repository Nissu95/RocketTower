using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSlimeAnimator : MonoBehaviour {
    CharacterController2D CC;
    public Animator anim;
    EnemyHealth health;
    // Use this for initialization
    void Start () {
        health = GetComponent<EnemyHealth>();
        CC = GetComponent<CharacterController2D>();
        health.OnHurt += OnHurt;
    }
    bool hurt = false;
	public void OnHurt(float damage)
    {
        hurt = true;
    }
	// Update is called once per frame
	void Update () {
		
	}
    private void LateUpdate()
    {
        if (hurt)
        {
            anim.SetTrigger("hurt");
            hurt = false;
        }
        anim.SetBool("isGrounded", CC.Col_isGrounded);        
    }
}
