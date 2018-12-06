using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamager : MonoBehaviour {

    [SerializeField] private float daño;

    private void OnTriggerEnter2D(Collider2D other)
    {
        int dir = (other.transform.position.x > transform.position.x) ? 1 : -1;
        PlayerHealth vidajugador = other.GetComponentInParent<PlayerHealth>();
        if (vidajugador != null)
        {
            vidajugador.Hurt(daño, dir);
        }
    }
}
