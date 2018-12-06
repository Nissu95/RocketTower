using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxListener : InputListener
{
    public XboxConfig config;
    void FixedUpdate()
    {
        config.Listen();
    }
    public override float AxisX()
    {
        return config.AxisX;
    }

    public override float AxisY()
    {
        return config.AxisY;
    }

    public override bool Fire1ButtonPress()
    {
        return config.Fire1.Press;
    }

    public override bool Fire1ButtonHold()
    {
        return config.Fire1.Hold;
    }

    public override bool JumpButtonHold()
    {
        return config.Jump.Hold;       
    }

    public override bool JumpButtonPress()
    {
        return config.Jump.Press;
    }

    public override void Listen()
    {
    }

    public override float SmoothAxisX()
    {
        return config.AxisX;
    }

    public override float SmoothAxisY()
    {
        return config.AxisY;
    }

    public override bool StartButtonPress()
    {
        return config.Start.Press;
    }

    public override bool StartButtonHold()
    {
        return config.Start.Hold;
    }

}

[System.Serializable]
public class XboxButton
{
    public string Name;
    public int JoystickInput = 0;
    bool Now;
    bool Prev;
    public XboxButton(string name)
    {
        Name = name;
    }
    public void SetInputSource(int source)
    {
        JoystickInput = source;
    }
    public void Listen()
    {
        Prev = Now;
        if (JoystickInput != 0)
        {
            Now = Input.GetButton("J" + JoystickInput + "_" + Name);
        }
        else
        {
            Now = Input.GetButton(Name);
        }
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
