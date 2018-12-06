using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostBasicAnimator : MonoBehaviour {
    public SpriteRenderer sprite;
    private InputListener input;
    private Jetpack jetpack;
    public ParticleSystem jetpackDust;
    public Vector3 jetpackDustInitPos;
    Animator anim;
    ActorPlayer playerScript;
    private bool facingRight;
    CharacterController2D CC;
    private PlayerHealth myHealth;
    // Use this for initialization
    void Start () {
        input = GetComponent<InputListener>();
        jetpack = GetComponent<Jetpack>();
        jetpackDustInitPos = jetpackDust.transform.localPosition;
        anim = sprite.GetComponent<Animator>();
        playerScript = GetComponent<ActorPlayer>();
        CC = GetComponent<CharacterController2D>();
        myHealth = GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        if (myHealth.Invulnerable)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 100);
        }
        else
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 255);
        }
        if (input.AxisX() != 0)
        {
            if (input.AxisX() > 0)
            {
                facingRight = true;
            }
            else
            {
                facingRight = false;
            }
        }
        if(sprite.flipX != facingRight)
        {
            sprite.flipX = facingRight;
            Vector3 localPos = jetpackDust.transform.localPosition;
            localPos.x = jetpackDustInitPos.x * (facingRight ? -1 : 1);
            jetpackDust.transform.localPosition = localPos;
        }        

        if (jetpack.inUse)
        {
            if (!jetpackDust.isEmitting)
            {                
                jetpackDust.Play(true);
            }            
        }
        else
        {
            if (jetpackDust.isEmitting)
            {
                jetpackDust.Stop(true, ParticleSystemStopBehavior.StopEmitting);

            }

        }

        anim.SetBool("isWalking", playerScript.input.AxisH != 0);
        anim.SetBool("isGrounded", CC.Col_isGrounded);
        anim.SetFloat("VerticalSpeed", CC.velocity.y);

    }
}
