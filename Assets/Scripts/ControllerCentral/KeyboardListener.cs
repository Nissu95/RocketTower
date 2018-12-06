using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardListener : InputListener
{
    public KeyboardConfig KeyboardConfig;
    
    void FixedUpdate()
    {
        KeyboardConfig.Listen();
    }
    public override bool JumpButtonPress()
    {
        return KeyboardConfig.Jump.Press;
    }
    public override bool JumpButtonHold()
    {
        return KeyboardConfig.Jump.Hold;
    }
    public override bool Fire1ButtonPress()
    {
        return KeyboardConfig.Fire1.Press;
    }
    public override bool Fire1ButtonHold()
    {
        return KeyboardConfig.Fire1.Hold;
    }
    public override float AxisX()
    {
        return KeyboardConfig.HorizontalAxis.Value;
    }
    public override float AxisY()
    {
        return KeyboardConfig.VerticalAxis.Value;
    }

    public override void Listen()
    {
       // throw new NotImplementedException();
    }

    public override float SmoothAxisX()
    {
        return KeyboardConfig.HorizontalAxis.SmoothValue;
    }

    public override float SmoothAxisY()
    {
        return KeyboardConfig.VerticalAxis.SmoothValue;
    }

    public override bool StartButtonPress()
    {
        return KeyboardConfig.Start.Press;
    }

    public override bool StartButtonHold()
    {
        return KeyboardConfig.Start.Hold;
    }

    public override void Vibrate(float leftMotor, float rightMotor)
    {
        //throw new NotImplementedException();
    }

}
