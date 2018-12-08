using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoins : MonoBehaviour {

    string coinTag = "Coin";
    IamPlayer iamPlayer;

    private void Awake()
    {
        iamPlayer = GetComponent<IamPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(coinTag))
        {
            collision.gameObject.SetActive(false);
            iamPlayer.score++;
        }
    }

}
