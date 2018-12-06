using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerManager : MonoBehaviour {
    public UnityEvent OnlyOnePlayerRemains;
    static List<IamPlayer> players = new List<IamPlayer>();
    static string winner = "Noone";
    static PlayerManager singleton;
	// Use this for initialization
	void Awake () {
        singleton = this;
        winner = "Noone";
        players = new List<IamPlayer>();
    }
    public static void AddPlayer(IamPlayer newPlayer)
    {
        players.Add(newPlayer);
        //Debug.Log("Added player: " + (players.Count - 1));
    }
    public static void RemovePlayer(IamPlayer dyingPLayer)
    {
        players.Remove(dyingPLayer);
        //Debug.Log("Removed player: " + (players.Count - 1));
        if (players.Count == 1)
        {
            if(winner =="Noone")
                winner = players[0].name;
            Debug.Log("Last player");
            if (singleton!=null)
                singleton.OnlyOnePlayerRemains.Invoke();
        }
    }	
    public static void SetWinner(string name)
    {
        winner = name;
    }
    public static string WinnerPlayerName()
    {        
        return winner;
    }
}
