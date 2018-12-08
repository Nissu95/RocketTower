using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActorPlayerInput
{
    private InputListener inputListener;

    public bool JumpPress;
    public bool JumpHold;
    public float AxisH;
    public float AxisV;
    public int facingDirection = -1;

    public ActorPlayerInput(GameObject go)
    {
        inputListener = go.GetComponent<InputListener>();
    }
    public void GetInput()
    {
        JumpPress = inputListener.JumpButtonPress();
        JumpHold = inputListener.JumpButtonHold();
        AxisH = inputListener.SmoothAxisX();
        AxisV = inputListener.AxisY();
        if (AxisH != 0)
            facingDirection = (int)Mathf.Sign(AxisH);
    }
}
[RequireComponent(typeof(CharacterController2D))]
public class ActorPlayer : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float airSpeed = 5;
    public float jumpForce = 15f;
    public float JumpButtonFallMultiplier = 0.5f;
    public bool JumpButtonOnFallOnly = true;
    public float JetpackForce = 15f;
    public float JetpackSpeed = 5f;
    public float timer = 2f;
    public bool RocketJumping = false;
    public Vector2 WalljumpForces;
    public ActorPlayerInput input;
    public ActorPlayerInput inpt;
    public CollisionPoint2D LeftWallJumpPoint;
    public CollisionPoint2D RightWallJumpPoint;
    public float WallJumpDistance = 0.65f;
    public bool isStunned = false;

    private Jetpack jetPack;
    float countdown;

    void Start()
    {
        countdown = timer;
        GetComponent<CharacterController2D>().OnPhysicsStep += PhysicsStep;
        input = new ActorPlayerInput(gameObject);
        inpt = input;
        jetPack = GetComponent<Jetpack>();

        LeftWallJumpPoint = new CollisionPoint2D(
            transform,
            Vector2.up * GetComponent<CharacterController2D>().CeilingCheckPoint / 2 - Vector2.right * WallJumpDistance,
            0.06f,
            GetComponent<CharacterController2D>().GroundLayers,
            1);

        RightWallJumpPoint = new CollisionPoint2D(
            transform,
            Vector2.up * GetComponent<CharacterController2D>().CeilingCheckPoint / 2 + Vector2.right * WallJumpDistance,
            0.06f,
            GetComponent<CharacterController2D>().GroundLayers,
            1);
    }

    private void Update()
    {
        if (countdown > 0 && isStunned)
        {
            countdown -= Time.deltaTime;
            input = null;
        }
        else
        {
            isStunned = false;
            countdown = timer;
            input = inpt;
        }
    }

    void JetpackEffect(CharacterController2D cc)
    {
        cc.velocity.y = Mathf.Lerp(cc.velocity.y, JetpackSpeed, 10f * Time.fixedDeltaTime);
        if (!prevRocketJumping)
            OnJetpackOn.Invoke();
    }

    enum MovementState { Walking, Air }

    void PhysicsStep(CharacterController2D cc)
    {
        LeftWallJumpPoint.TestCollision(Time.fixedDeltaTime);
        RightWallJumpPoint.TestCollision(Time.fixedDeltaTime);

        if (input != null)
            input.GetInput();

        if (cc.Col_isGrounded)
        {
            MoveOnGround(cc);
            if (input != null)
                if (input.JumpPress && cc.Ground.CollidedLastUpdate)
                    cc.Push(input.AxisH * walkSpeed, 0);
        }
        else
            MoveOnAir(cc);
        if (RocketJumping)
            JetpackEffect(cc);
        else
        {
            if (prevRocketJumping)
                OnJetpackOff.Invoke();
        }
        prevRocketJumping = RocketJumping;
    }

    bool prevRocketJumping = false;

    void MoveOnGround(CharacterController2D cc)
    {
        jetPack.Fill(Time.fixedDeltaTime);

        if (input != null)
        {
            if (input.JumpPress)
            {
                if (input.AxisV > -0.25f)
                {
                    cc.velocity.y += jumpForce;
                    OnJumping.Invoke();
                }
            }
            cc.Movement += Vector2.right * input.AxisH * walkSpeed * Time.fixedDeltaTime;
            ContinueRocketJump(cc);
        }
    }

    void MoveOnAir(CharacterController2D cc)
    {
        if (SlidingOnWall(cc))
            cc.velocity.y = -0.4f;

        if (input != null)
        {
            if (input.JumpPress)
            {
                if (LeftWallJumpPoint.Collided)// && input.AxisH > 0)
                {
                    if (input.JumpPress)
                    {
                        OnWallJumping.Invoke();
                        cc.Push(WalljumpForces.x, WalljumpForces.y);
                    }
                }
                else
                {
                    if (RightWallJumpPoint.Collided)// && input.AxisH < 0)
                    {
                        if (input.JumpPress)
                        {
                            OnWallJumping.Invoke();
                            cc.Push(-WalljumpForces.x, WalljumpForces.y);
                        }
                    }
                    else
                        RocketJumping = jetPack.Use(Time.fixedDeltaTime);
                }
            }
            ContinueRocketJump(cc);
            cc.velocity.x = Mathf.Lerp(cc.velocity.x, input.AxisH * airSpeed, 2f * Time.fixedDeltaTime);
        }
        else
            cc.velocity.x = Mathf.Lerp(cc.velocity.x, airSpeed, 2f * Time.fixedDeltaTime);
    }
    bool SlidingOnWall(CharacterController2D cc)
    {
        if (input != null)
            return !RocketJumping && (((cc.Col_wallLeft && input.AxisH < 0) || (cc.Col_wallRight && input.AxisH > 0)) && cc.velocity.y < 0.4f);
        else
            return false;
    }


    void ContinueRocketJump(CharacterController2D cc)
    {
        if (input.JumpHold)
        {
            RocketJumping = RocketJumping && jetPack.Use(Time.fixedDeltaTime);
            if (!JumpButtonOnFallOnly || (JumpButtonOnFallOnly && cc.velocity.y <= 0))
                cc.velocity -= Vector2.down * cc.gravity * cc.gravityMultiplier * JumpButtonFallMultiplier * Time.fixedDeltaTime;
        }
        else
            RocketJumping = false;
    }
    private void OnDrawGizmos()
    {
        if (LeftWallJumpPoint != null)
            LeftWallJumpPoint.DrawGizmos();
        if (RightWallJumpPoint != null)
            RightWallJumpPoint.DrawGizmos();
    }
    public UnityEvent OnJumping;
    public UnityEvent OnWallJumping;
    public UnityEvent OnJetpackOn;
    public UnityEvent OnJetpackOff;
}
[System.Serializable]
public class Timer
{
    [SerializeField]
    float top;
    [SerializeField]
    float countdown;

    public bool Done
    {
        get { return countdown <= 0; }
    }

    public Timer(float Top)
    {
        this.top = Top;
        this.countdown = Top;
    }
    public Timer(float Top, float InitialValue)
    {
        this.top = Top;
        this.countdown = InitialValue;
    }
    public bool Step(float time)
    {
        countdown -= time;
        return countdown <= 0;
    }
    public void Reset()
    {
        countdown = top;
    }
}