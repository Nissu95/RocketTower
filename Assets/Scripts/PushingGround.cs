using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingGround : GroundProperties {

    public Vector2 movement = new Vector2(1, 0);
    public override void OnStandOn(IPusheable actor)
    {
        actor.AddMovement(movement.x, movement.y);
    }
}
