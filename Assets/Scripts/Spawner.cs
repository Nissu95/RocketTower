using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IGameAreaObserver {
    
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private float spawnRateMin;       // Cada cuantos segundos spawnea un prefab
    [SerializeField] private float spawnRateMax;       // Cada cuantos segundos spawnea un prefab

    List<GameObject> Children = new List<GameObject>();

    public int MaxChildren = 3;

    void Spawn(){
        if (inside)
            Invoke("Spawn", Random.Range(spawnRateMin, spawnRateMax));

        if (Children.Count>MaxChildren) return;

        GameObject objeto = Instantiate(prefab[Random.Range(0, prefab.Length)]);
        objeto.transform.position = transform.position;
        objeto.transform.rotation = transform.rotation;
        Children.Add(objeto);
               
    }
    bool inside = false;

    /*public void OnBecameVisible()
    {
        if(Camera.current == Camera.main)
        {

        }
    }

    private void OnBecameInvisible()
    {

    }*/

    public void OnEnterGameArea()
    {
        Invoke("Spawn", 0.1f);
        inside = true;
    }

    public void OnExitGameArea()
    {
        inside = false;
        //CancelInvoke();
    }
}
