using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Keyboard Config", menuName="Controller/New Keyboard Config")]
public class KeyboardConfig : ScriptableObject {
    public KeyboardAxis VerticalAxis;
    public KeyboardAxis HorizontalAxis;
    public KeyboardButton Jump;
    public KeyboardButton Fire1;
    public KeyboardButton Start;
    public void Listen()
    {
        Start.Listen();
        Jump.Listen();
        Fire1.Listen();
        VerticalAxis.Listen();
        HorizontalAxis.Listen();
    }
    
    public float AxisX()
    {
        return (HorizontalAxis.Value);
    }
    public float AxisY()
    {
        return (VerticalAxis.Value);
    }
}
