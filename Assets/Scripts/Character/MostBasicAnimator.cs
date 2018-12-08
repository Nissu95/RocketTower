using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostBasicAnimator : MonoBehaviour
{

    private InputListener input;
    private Jetpack jetpack;
    private PlayerHealth myHealth;
    private bool facingRight;

    Animator anim;
    ActorPlayer playerScript;
    CharacterController2D CC;

    public Vector3 jetpackDustInitPos;
    public ParticleSystem jetpackDust;
    public SpriteRenderer sprite;

    void Start()
    {
        input = GetComponent<InputListener>();
        jetpack = GetComponent<Jetpack>();
        jetpackDustInitPos = jetpackDust.transform.localPosition;
        anim = sprite.GetComponent<Animator>();
        playerScript = GetComponent<ActorPlayer>();
        CC = GetComponent<CharacterController2D>();
        myHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (myHealth.Invulnerable)
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 100);
        else
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 255);

        if (!playerScript.isStunned)
        {
            if (input.AxisX() != 0)
            {
                if (input.AxisX() > 0)
                    facingRight = true;
                else
                    facingRight = false;
            }
        }


        if (sprite.flipX != facingRight)
        {
            sprite.flipX = facingRight;
            Vector3 localPos = jetpackDust.transform.localPosition;
            localPos.x = jetpackDustInitPos.x * (facingRight ? -1 : 1);
            jetpackDust.transform.localPosition = localPos;
        }

        if (jetpack.inUse)
        {
            if (!jetpackDust.isEmitting)
                jetpackDust.Play(true);
        }
        else
        {
            if (jetpackDust.isEmitting)
                jetpackDust.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        if (!playerScript.isStunned)
        {
            anim.SetBool("isWalking", playerScript.input.AxisH != 0);
            anim.SetBool("isGrounded", CC.Col_isGrounded);
            anim.SetFloat("VerticalSpeed", CC.velocity.y);
        }
    }
}
