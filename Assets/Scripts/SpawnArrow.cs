using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour {

    [SerializeField] GameObject spawnArrow;

    public GameObject GetSpawnArrow()
    {
        return spawnArrow;
    }

}