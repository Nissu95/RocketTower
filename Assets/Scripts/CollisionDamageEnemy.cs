using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageEnemy : MonoBehaviour {
    int dir = 1;
    [SerializeField] private float damage;
    private InputListener input;
    private ActorPlayer actorPlayer;
    public float cooldown = 0.2f;
    float cooldownCountdown;
    public Vector2 DirectionalPush = new Vector2(15,10);
    public float damageDuration = 0.1f;
    public float damageCountdown;
    public SpriteRenderer r;
    public Animator anim;
    private Jetpack jet;

    void Start()
    {
        input = GetComponentInParent<InputListener>();
        r = GetComponent<SpriteRenderer>();
        actorPlayer = GetComponentInParent<ActorPlayer>();
        anim = GetComponent<Animator>();
        cooldownCountdown = cooldown;
        damageCountdown = 0;
        jet = GetComponentInParent<Jetpack>();
    }
    private void Update()
    {

        if (cooldownCountdown > 0)
        {
            //r.color = new Color(1, 1, 1, 1);
            cooldownCountdown -= Time.deltaTime;
        }
        else
        {
            //r.color = new Color(1, 1, 1, 0);
        }       
    }
    private void FixedUpdate()
    {
        if (cooldownCountdown <= 0)
        {
            if (input.Fire1ButtonPress())
            {
                anim.SetTrigger("Attack");
                cooldownCountdown = cooldown;
                damageCountdown = damageDuration;
            }
        }
        else
        {
            cooldownCountdown -= Time.fixedDeltaTime;
            damageCountdown -= Time.fixedDeltaTime;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (damageCountdown > 0)
        {            
            switch (other.tag)
            {
                case "Player":
                    PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                    Debug.Log("Hurt Player" + actorPlayer.input.facingDirection);
                    playerHealth.Hurt(0, new Vector2(actorPlayer.input.facingDirection * 15 * DirectionalPush.x, input.AxisY() * DirectionalPush.y));
                    jet.SmallRefill();
                   
                    break;
                case "Enemy":
                    EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();                    
                    if (enemyHealth != null)
                    {
                        Debug.Log("Hurt Enemy" + actorPlayer.input.facingDirection);
                        enemyHealth.Hurt(damage, actorPlayer.input.facingDirection);
                    }
                    break;
            }
        }       
    }
}
