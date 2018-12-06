using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyboardButton {
    public KeyCode Key;
    bool Now;
    bool Prev;
    public void Listen()
    {
        Prev = Now;
        Now = Input.GetKey(Key);
    }

    public bool Press
    {
        get { return (!Prev && Now); }
    }
    public bool Hold
    {
        get { return (Now); }
    }
}
