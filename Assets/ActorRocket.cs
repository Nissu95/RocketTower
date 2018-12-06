using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorRocket : MonoBehaviour {
    public float speed = 2f;
    public bool Accelerate = false;
    public float damage = 25;
	void Start () {
        GetComponent<CharacterController2D>().OnPhysicsStep += PhysicsStep;
    }
	void PhysicsStep(CharacterController2D cc)
    {
        if (Accelerate)
        {
            //cc.Accelerate(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed, Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed);
        }
        else{
            cc.Push(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed, Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.Hurt(damage, (transform.rotation.eulerAngles.z<90 && transform.rotation.eulerAngles.z > -90)?1:-1);
                break;
        }
        Kill();
    }
    public void Kill()
    {
        SoundManager.PlaySound(gameObject, deathSound);
        GetComponent<DeathExplotion>().Die();
    }
    public AudioClip deathSound;
}
