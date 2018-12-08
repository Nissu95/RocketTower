using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageEnemy : MonoBehaviour
{

    [SerializeField] private float damage;

    public Vector2 DirectionalPush = new Vector2(15, 10);
    public float damageDuration = 0.1f;
    public float damageCountdown;
    public SpriteRenderer r;
    public Animator anim;
    public float cooldown = 0.2f;

    private InputListener input;
    private ActorPlayer actorPlayer;
    private Jetpack jet;
    public CharacterController2D CC;

    float cooldownCountdown;
    int dir = 1;

    void Start()
    {
        input = GetComponentInParent<InputListener>();
        r = GetComponent<SpriteRenderer>();
        actorPlayer = GetComponentInParent<ActorPlayer>();
        anim = GetComponent<Animator>();
        cooldownCountdown = cooldown;
        damageCountdown = 0;
        jet = GetComponentInParent<Jetpack>();
        //CC.GetComponentInParent<CharacterController2D>();
    }

    /* private void Update()
     {
         if (vibrationCountdown > 0 && isVibrating)
         {
             input.Vibrate(0.5f, 0.5f);
             vibrationCountdown -= Time.deltaTime;
         }
         else
         {
             input.Vibrate(0.0f, 0.0f);
             isVibrating = false;
             vibrationCountdown = VibrationTime;
         }

         if (cooldownCountdown > 0)
         {
             //r.color = new Color(1, 1, 1, 1);
             cooldownCountdown -= Time.deltaTime;
         }
         else
         {
             //r.color = new Color(1, 1, 1, 0);
         }
     }*/

    private void FixedUpdate()
    {
        if (!actorPlayer.isStunned)
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
                    ActorPlayer otherActorPlayer = other.GetComponent<ActorPlayer>();
                    VibrateJoystock otherJoystick = other.GetComponent<VibrateJoystock>();
                    //Debug.Log("Hurt Player" + actorPlayer.input.facingDirection);
                    playerHealth.Hurt(0, new Vector2(actorPlayer.input.facingDirection * 15 * DirectionalPush.x, input.AxisY() * DirectionalPush.y));
                    otherJoystick.SetVibrating(true);
                    otherActorPlayer.isStunned = true;
                    jet.SmallRefill();
                    break;
                case "Enemy":
                    EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        //Debug.Log("Hurt Enemy" + actorPlayer.input.facingDirection);
                        enemyHealth.Hurt(damage, actorPlayer.input.facingDirection);
                    }
                    break;
            }
        }
    }
}
