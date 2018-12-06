
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Xbox Config", menuName = "Controller/New Xbox Config")]
public class XboxConfig : ScriptableObject
{
    bool RawAxis = true;
    public int JoystickInput = 0;
    public XboxButton Jump;
    public XboxButton Fire1;
    public XboxButton Start;
    public void Listen()
    {
        Jump.SetInputSource(JoystickInput);
        Fire1.SetInputSource(JoystickInput);
        Start.SetInputSource(JoystickInput);
        Jump.Listen();
        Fire1.Listen();
        Start.Listen();
    }
    private string JoyPrefix
    {
        get { return "J"+ JoystickInput +"_"; }
    }
    public float AxisX
    {
        get { return RawAxis ? Input.GetAxisRaw(JoyPrefix+"Horizontal") : Input.GetAxis(JoyPrefix+"Horizontal"); }
    }
    public float AxisY
    {
        get { return RawAxis ? Input.GetAxisRaw(JoyPrefix+"Vertical") : Input.GetAxis(JoyPrefix+"Vertical"); }
    }
}
