using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPusheable {
    Vector2 GetExternalMovement();
    void AddMovement(float X, float Y);
}
