using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour {
    public GameObject prefab;
    public Transform SpawnPoint;
    public void Spawn()
    {
        GameObject instance = GameObject.Instantiate<GameObject>(prefab);
        instance.transform.position = SpawnPoint.position;
        instance.transform.rotation = SpawnPoint.rotation;
    }	
}
