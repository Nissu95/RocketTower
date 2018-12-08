using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerManager : MonoBehaviour
{
    public UnityEvent OnlyOnePlayerRemains;
    public static int scoreAddOnlyOnePlayer = 10;


    static List<IamPlayer> players = new List<IamPlayer>();
    static List<IamPlayer> iamPlayers;
    static string winner;
    static int winnerScore = 0;
    static PlayerManager singleton;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;

        //winner = "Noone";
        players = new List<IamPlayer>();
        iamPlayers = players;
    }

    public static void AddPlayer(IamPlayer newPlayer)
    {
        players.Add(newPlayer);
        //Debug.Log("Added player: " + (players.Count - 1));
    }

    public static void RemovePlayer(IamPlayer dyingPLayer)
    {
        iamPlayers = players;
        players.Remove(dyingPLayer);
        //Debug.Log("Removed player: " + (players.Count - 1));
        if (players.Count == 1)
        {
            players[0].score += scoreAddOnlyOnePlayer;

            SetWinner();

            if (singleton != null)
                singleton.OnlyOnePlayerRemains.Invoke();
        }
    }

    /*public static void PlayerFinish(IamPlayer player, int scoreAdd)
    {
        for (int i = 0; i < players.Capacity; i++)
        {
            if (players[i] == player)
                players[i].score += scoreAdd;
        }

        SetWinner();

        GameManager.Singleton.Win();
    }*/

    private void Update()
    {
        SetWinner();
    }

    public static void SetWinner()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].score > winnerScore)
            {
                winner = players[i].name;
                winnerScore = players[i].score;
            }

        }
    }

    public static void SetWinnerScore(int _score)
    {
        winnerScore = _score;
    }

    public static int GetWinnerScore()
    {
        return winnerScore;
    }

    public static string WinnerPlayerName()
    {
        return winner;
    }
}
