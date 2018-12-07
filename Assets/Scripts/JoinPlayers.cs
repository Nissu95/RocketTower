using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinPlayers : MonoBehaviour {

    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;
    [SerializeField] GameObject playerThree;
    [SerializeField] GameObject playerFour;

    private void Start()
    {
        switch (GameManager.Singleton.GetCantPlayers())
        {
            case 1:
                playerOne.SetActive(true);
                break;
            case 2:
                playerOne.SetActive(true);
                playerTwo.SetActive(true);
                break;
            case 3:
                playerOne.SetActive(true);
                playerTwo.SetActive(true);
                playerThree.SetActive(true);
                break;
            case 4:
                playerOne.SetActive(true);
                playerTwo.SetActive(true);
                playerThree.SetActive(true);
                playerFour.SetActive(true);
                break;
        }
    }

}
