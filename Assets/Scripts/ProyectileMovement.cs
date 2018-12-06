using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileMovement : MonoBehaviour {

    [SerializeField] private float velocity;

	void Update () {
        transform.Translate(velocity * Time.deltaTime, 0, 0);
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
