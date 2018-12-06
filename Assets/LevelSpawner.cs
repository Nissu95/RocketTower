using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour {
    int elegido = 0;
    int previo = -1;
    [SerializeField] private GameObject[] prefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LevelSignal")
        {
            //Debug.Log("ENTRE");
            elegido = Random.Range(0, prefab.Length);
            while (elegido == previo)
            {
                elegido = Random.Range(0, prefab.Length);
            }
            GameObject objeto = Instantiate(prefab[elegido]);
            objeto.transform.position = transform.position;
            objeto.transform.rotation = transform.rotation;
            previo = elegido;
       }
    }
}