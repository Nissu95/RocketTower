using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunStars_Script : MonoBehaviour {

    [SerializeField] GameObject starsStun;
    [SerializeField] ActorPlayer actorPlayer;

    private void Update()
    {
        if (actorPlayer.isStunned)
            starsStun.SetActive(true);
        else
            starsStun.SetActive(false);
    }

}
