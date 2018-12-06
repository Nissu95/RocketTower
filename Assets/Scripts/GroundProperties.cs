using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GroundProperties : MonoBehaviour {

    public abstract void OnStandOn(IPusheable actor);
}
