using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LiveCounterUI : MonoBehaviour {
    [SerializeField] private string jugadorAsignado;
    [SerializeField] private Sprite[] cantVidas;
    private GameObject jugador;
    private PlayerHealth vidaJugador;
    private Image contadorVidas;
    private int currentLives;

    private void Awake()
    {
        jugador = GameObject.Find(jugadorAsignado);
        if (jugador != null)
        {
            contadorVidas = GetComponent<Image>();
            vidaJugador = jugador.gameObject.GetComponent<PlayerHealth>();
        }
        else if (jugador == null)
        {
            Destroy(gameObject);
        }
    }

    public void Update(){
        currentLives = vidaJugador.CurrentLives;
        contadorVidas.sprite = cantVidas[currentLives];
    }
}
