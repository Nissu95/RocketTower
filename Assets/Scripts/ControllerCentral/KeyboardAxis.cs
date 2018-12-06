using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyboardAxis {
    public KeyCode Positive;
    public KeyCode Negative;

    public float SmoothValue = 0f;
    public void Listen()
    {
        SmoothValue = Mathf.Lerp(SmoothValue, Value, 0.35f);
        if (Mathf.Abs(SmoothValue) < 0.05)
        {
            SmoothValue = 0;
        }
        if (Mathf.Abs(Mathf.Abs(SmoothValue) - 1) < 0.05)
        {
            SmoothValue = 1 * Mathf.Sign(SmoothValue);
        }
    }
    public float Value
    {
        get { return (Input.GetKey(Positive) ? 1 : 0) - (Input.GetKey(Negative) ? 1 : 0); }
    }
}
