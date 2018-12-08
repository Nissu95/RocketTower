using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void HurtDelegate(float v);
public class EnemyHealth : MonoBehaviour {
	
    [SerializeField] private float health;
    public Vector2 OnDamagePush = new Vector2(5, 5);
    public HurtDelegate OnHurt;
    CharacterController2D cc;
    private void Awake()
    {
        cc = GetComponent<CharacterController2D>();
    }
    public float Quantity
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
                Destroy(gameObject);
        }
    }
    
   
    public virtual void Hurt(float damage, int dir)
    {
        Quantity -= damage;
        //Debug.Log("Jumping to:" + dir * OnDamagePush.x + "," + OnDamagePush.y);
        cc.ignoreFloor = true;
        cc.Push(dir * OnDamagePush.x, OnDamagePush.y);
        if (OnHurt != null)
        {
            OnHurt(damage);
        }
    }
   
}
