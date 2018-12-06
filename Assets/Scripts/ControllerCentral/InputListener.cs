using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputListener : MonoBehaviour {
    abstract public void Listen();
    abstract public bool JumpButtonPress();
    abstract public bool JumpButtonHold();
    abstract public bool Fire1ButtonPress();
    abstract public bool Fire1ButtonHold();
    abstract public bool StartButtonPress();
    abstract public bool StartButtonHold();
    abstract public float AxisX();
    abstract public float SmoothAxisX();
    abstract public float AxisY();
    abstract public float SmoothAxisY();
    //abstract public bool Start1ButtonPress();
}
