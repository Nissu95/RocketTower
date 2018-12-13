using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerManager : MonoBehaviour
{
    public UnityEvent OnlyOnePlayerRemains;
    public static int scoreAddOnlyOnePlayer = 3;

    static List<IamPlayer> players = new List<IamPlayer>();
    static List<IamPlayer> iamPlayers;
    static string winner;
    static int winnerScore = 0;
    static PlayerManager singleton;
    static Sprite winnerSprite;
    static Color winnerColor;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;

        //winner = "Noone";
        players = new List<IamPlayer>();
        iamPlayers = new List<IamPlayer>();
    }

    public static void AddPlayer(IamPlayer newPlayer)
    {
        players.Add(newPlayer);
        iamPlayers.Add(newPlayer);
        //Debug.Log("Added player: " + (players.Count - 1));
    }

    public static void RemovePlayer(IamPlayer dyingPLayer)
    {
        //iamPlayers = players;
        players.Remove(dyingPLayer);
        //Debug.Log("Removed player: " + (players.Count - 1));
        if (players.Count == 1)
        {
            players[0].score += scoreAddOnlyOnePlayer * (players[0].GetComponent<PlayerHealth>().CurrentLives + 1);
            
            SetWinner();

            if (singleton != null)
                singleton.OnlyOnePlayerRemains.Invoke();
        }
    }

    public static void SetWinner()
    {
        Debug.Log("1st" + iamPlayers.Count);
        for (int i = 0; i < iamPlayers.Count; i++)
        {
            if (iamPlayers[i].score > winnerScore)
            {
                winner = iamPlayers[i].name;
                winnerSprite = iamPlayers[i].GetComponentInChildren<SpriteRenderer>().sprite;
                winnerColor = iamPlayers[i].GetComponentInChildren<SpriteRenderer>().color;
                winnerScore = iamPlayers[i].score;
            }
        }

        iamPlayers.Clear();

        /*Debug.Log("2nd" + iamPlayers.Count);
        for (int i = 0; i < iamPlayers.Count; i++)
            iamPlayers.Remove(iamPlayers[i]);*/
        Debug.Log("3rd" + iamPlayers.Count);
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

    public static Sprite GetWinnerSprite()
    {
        return winnerSprite;
    }

    public static Color GetWinnerColor()
    {
        return winnerColor;
    }
}
