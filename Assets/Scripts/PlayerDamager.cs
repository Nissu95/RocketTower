using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamager : MonoBehaviour {

    [SerializeField] private float daño;

    VibrateJoystick vibrateJoystick;
    PlayerHealth vidajugador;

    /*private void OnTriggerStay2D(Collider2D other)
    {
        int dir = (other.transform.position.x > transform.position.x) ? 1 : -1;
        vidajugador = other.GetComponentInParent<PlayerHealth>();
        if (vidajugador != null)
            vidajugador.Hurt(daño, dir);
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        int dir = (other.transform.position.x > transform.position.x) ? 1 : -1;
        vidajugador = other.GetComponentInParent<PlayerHealth>();
        vibrateJoystick = other.GetComponent<VibrateJoystick>();
        if (vidajugador != null)
            vidajugador.Hurt(daño, dir);
        if (vibrateJoystick)
            vibrateJoystick.SetVibrating(true);
    }
}
