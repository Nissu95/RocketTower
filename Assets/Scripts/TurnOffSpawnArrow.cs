using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSpawnArrow : MonoBehaviour {

    [SerializeField] float timer;

    float countdown;

    private void OnEnable()
    {
        countdown = timer;
    }

    private void Update()
    {
        if (countdown > 0)
            countdown -= Time.deltaTime;
        else
        {
            gameObject.SetActive(false);
        }
    }

}
