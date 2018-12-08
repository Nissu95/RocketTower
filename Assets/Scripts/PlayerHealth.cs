using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private int lives;

    public Vector2 OnDamagePush = new Vector2(5, 5);
    CharacterController2D cc;
    private float maxHealth;

    public bool Invulnerable
    {
        get { return invulCountdown > 0; }

    }
    void Awake()
    {
        maxHealth = health;
        cc = GetComponent<CharacterController2D>();
        invulCountdown = 0;
    }

    public int CurrentLives
    {
        get { return lives; }
    }

    public float Quantity
    {
        get { return health; }
    }
    public virtual void Kill()
    {
        health = 0;
        die();
    }
    private void die()
    {
        if (lives <= 0)
            Destroy(gameObject);
        else
        {
            lives--;
            health = maxHealth;
            RespawnPointManager.RequestRespawn(gameObject);
        }
    }
    public void Update()
    {
        if (invulCountdown > 0)
        {
            invulCountdown -= Time.deltaTime;
        }
    }

    public float InvulTime = 2f;
    float invulCountdown;

    public virtual void Hurt(float damage, int dir)
    {
        if (invulCountdown <= 0)
        {
            invulCountdown = InvulTime;
            health -= damage;
            if (health <= 0)
                die();

            //Debug.Log("Jumping to:" + dir * OnDamagePush.x + "," + OnDamagePush.y);
            cc.ignoreFloor = true;
            cc.SetSpeed(dir * OnDamagePush.x, OnDamagePush.y);
        }
    }
    public virtual void Hurt(float damage, Vector2 dir)
    {
        if (invulCountdown <= 0)
        {
            if (damage != 0)
                invulCountdown = InvulTime;

            health -= damage;
            if (health <= 0)
            {
                die();
            }
            cc.ignoreFloor = true;
            cc.SetSpeed(dir.x, dir.y);
        }
    }
}
