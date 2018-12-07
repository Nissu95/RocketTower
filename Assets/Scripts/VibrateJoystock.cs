using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateJoystock : MonoBehaviour {

    [SerializeField] float VibrationTime = 1.0f;

    bool isVibrating = false;
    InputListener input;
    float vibrationCountdown;

    private void Start()
    {
        input = GetComponent<InputListener>();
        vibrationCountdown = VibrationTime;
    }

    private void FixedUpdate()
    {
        if (vibrationCountdown > 0 && isVibrating)
        {
            input.Vibrate(0.5f, 0.5f);
            vibrationCountdown -= Time.fixedDeltaTime;
        }
        else
        {
            input.Vibrate(0.0f, 0.0f);
            isVibrating = false;
            vibrationCountdown = VibrationTime;
        }
    }

    public void SetVibrating(bool _isVibrating)
    {
        isVibrating = _isVibrating;
    }

}
