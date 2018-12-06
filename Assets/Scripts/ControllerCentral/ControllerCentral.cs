using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;

public class ControllerCentral : MonoBehaviour {

    public int MaxPlayers = 4;
    public List<PlayerJoystick> PlayerJoysticks;
	// Use this for initialization
	void Start () {
        GetAllJoystickTypes();
    }
	
	// Update is called once per frame
	void Update () {
        ListenForNewPlayers();
    }

    void ListenForNewPlayers()
    {
        for(int i=0; i< JoystickListeners.Count; i++)
        {
            JoystickListeners[i].ListenCustom();
        }
    }

    public void StartListeningForNewPlayers()
    {

    }
    public List<PlayerJoystick> JoystickListeners = new List<PlayerJoystick>();
    private void GetAllJoystickTypes()
    {
        IEnumerable<PlayerJoystick> exporters = typeof(PlayerJoystick)
        .Assembly.GetTypes()
        .Where(t => t.IsSubclassOf(typeof(PlayerJoystick)) && !t.IsAbstract)
        .Select(t => (PlayerJoystick)Activator.CreateInstance(t));
        JoystickListeners = new List<PlayerJoystick>(exporters);
    }

    public void OnJoysticDisconnected()
    {

    }
}
