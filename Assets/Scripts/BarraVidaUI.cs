using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraVidaUI : MonoBehaviour
{
    [SerializeField] private string jugadorAsignado;

    private GameObject jugador;
    private PlayerHealth vidaJugador;
    private Image barraVida;

    private void Awake()
    {
        jugador = GameObject.Find(jugadorAsignado);

        if (jugador != null)
        {
            barraVida = GetComponent<Image>();
            vidaJugador = jugador.gameObject.GetComponent<PlayerHealth>();
        }
        else if(jugador == null)
        {
            Destroy(gameObject);
        }
        
    }

    public void Update(){
        barraVida.fillAmount = vidaJugador.Quantity / 100;
    }
}
