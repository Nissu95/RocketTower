using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrolActor : MonoBehaviour {
    public float walkSpeed = 1f;
    public int walkDirection = 1;
	// Use this for initialization
	void Start () {
        GetComponent<CharacterController2D>().OnPhysicsStep += PhysicsStep;
    }
    void PhysicsStep(CharacterController2D cc)
    {
        
        if (cc.Col_isGrounded)
        {
            if (walkDirection > 0)
            {
                if (cc.Col_fallRight||cc.Col_wallRight)
                {
                    walkDirection = -1;
                }
            }
            else
            {
                if (cc.Col_fallLeft || cc.Col_wallLeft)
                {
                    walkDirection = 1;
                }
            }
            cc.Movement += Vector2.right * walkDirection * walkSpeed * Time.fixedDeltaTime;
        } 
    }
}
