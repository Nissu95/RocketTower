using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LiveCounterUI : MonoBehaviour
{
    [SerializeField] private Sprite[] cantVidas;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerUI;

    private PlayerHealth vidaJugador;
    private Image contadorVidas;
    private int currentLives;

    private void Start()
    {
        if (player.activeInHierarchy)
        {
            contadorVidas = GetComponent<Image>();
            vidaJugador = player.gameObject.GetComponent<PlayerHealth>();
        }
        else if (!player.activeInHierarchy)
        {
            playerUI.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        currentLives = vidaJugador.CurrentLives;
        contadorVidas.sprite = cantVidas[currentLives];
    }
}
