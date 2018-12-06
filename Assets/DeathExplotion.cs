using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathExplotion : MonoBehaviour
{
    public GameObject DeathGameObject;
    public void Die()
    {
        GameObject fallSprite = GameObject.Instantiate<GameObject>(DeathGameObject);
        fallSprite.transform.position = transform.position;
        this.enabled = false;
        GameObject.Destroy(gameObject);
    }
}
