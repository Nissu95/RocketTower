using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void PhysicsStepDelegate(CharacterController2D cc);

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour, IPusheable
{
    public bool ignoreFloor = false;
    bool leftGround = false;
    public CollisionPoint2D Ground;
    public bool Col_isGrounded;
    public bool Col_wallLeft;
    public bool Col_fallLeft;
    public bool Col_wallRight;
    public bool Col_fallRight;
    public bool Col_ceiling;

    public float gravityMultiplier = 1f;
    public float gravity = 9.8f;
    public float GroundCheckPoint;
    public float GroundCheckRadius = 0.06f;
    public float CeilingCheckPoint;
    public float SideCheckPoint;
    public float fallCheckPoint;
    public float OneSidedGroundPoint;
    public Vector3 LastOneSidedGroundPoint;
    Vector2 externalMovement = Vector2.zero;

    public void AddMovement(float X, float Y)
    {
        externalMovement += new Vector2(X, Y);
    }

    public Vector2 GetExternalMovement()
    {
        return externalMovement;
    }

    public void Push(float X, float Y)
    {
        velocity += new Vector2(X, Y);
    }

    public void SetSpeed(float X, float Y)
    {
        velocity = new Vector2(X, Y);
    }

    void ClampSpeed()
    {
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);

        if (Col_wallRight)
            velocity.x = Mathf.Clamp(velocity.x, -100f, 0f);
        if (Col_wallLeft)
            velocity.x = Mathf.Clamp(velocity.x, 0f, 100f);
        if (Col_isGrounded)
            velocity.y = Mathf.Clamp(velocity.y, -gravity * Time.fixedDeltaTime, 100f);
        else
            if (Col_ceiling)
                velocity.y = Mathf.Clamp(velocity.y, -100f, 0f);
    }

    private Rigidbody2D rb;
    public Vector2 velocity;
    public float maxSpeed = 15f;

    public LayerMask GroundLayers;
    public LayerMask WallLayers;
    public LayerMask OneSidedGroundLayers;
    private Collider2D[] TouchingGround;
    private ContactFilter2D cf2D;
    private ContactFilter2D cf2DWalls;
    private RaycastHit2D[] TouchingGround_OneSided;
    private ContactFilter2D cf2D_OneSided;

    public PhysicsStepDelegate OnPhysicsStep;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        TouchingGround = new Collider2D[1];
        cf2D = new ContactFilter2D();
        cf2D.SetLayerMask(GroundLayers);

        cf2DWalls = new ContactFilter2D();
        cf2DWalls.SetLayerMask(WallLayers + GroundLayers);

        cf2D_OneSided = new ContactFilter2D();
        cf2D_OneSided.SetLayerMask(OneSidedGroundLayers);
        TouchingGround_OneSided = new RaycastHit2D[1];
        LastOneSidedGroundPoint = transform.position + Vector3.down * OneSidedGroundPoint;

        Ground = new CollisionPoint2D(
           transform,
           Vector3.up * GroundCheckPoint,
           GroundCheckRadius,
           GroundLayers + OneSidedGroundLayers,
           1);
    }

    public Vector2 Movement;
    public bool Col_GroundIsOneSided = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        Ground.TestCollision(Time.fixedDeltaTime);

        Col_isGrounded = Physics2D.OverlapCircle(transform.position + Vector3.up * GroundCheckPoint, GroundCheckRadius, cf2D, TouchingGround) > 0;
        Col_ceiling = Physics2D.OverlapCircle(transform.position + Vector3.up * CeilingCheckPoint, 0.06f, GroundLayers);
        Col_wallLeft = Physics2D.OverlapCircle(transform.position + Vector3.up * CeilingCheckPoint / 2 - Vector3.right * SideCheckPoint, 0.06f, WallLayers);
        Col_wallRight = Physics2D.OverlapCircle(transform.position + Vector3.up * CeilingCheckPoint / 2 + Vector3.right * SideCheckPoint, 0.06f, WallLayers);
        Col_fallLeft = !Physics2D.OverlapCircle(transform.position - Vector3.right * SideCheckPoint + Vector3.down * fallCheckPoint, 0.06f, WallLayers);
        Col_fallRight = !Physics2D.OverlapCircle(transform.position + Vector3.right * SideCheckPoint + Vector3.down * fallCheckPoint, 0.06f, WallLayers);
        Movement = Vector2.zero;

        Vector3 CurrentOneSidedGroundPoint = transform.position + Vector3.down * OneSidedGroundPoint;
        if (!Col_isGrounded && velocity.y < 0 && 0 < Physics2D.Raycast(LastOneSidedGroundPoint, (CurrentOneSidedGroundPoint) - LastOneSidedGroundPoint, cf2D_OneSided, TouchingGround_OneSided, ((CurrentOneSidedGroundPoint) - LastOneSidedGroundPoint).magnitude))
        {
            Col_isGrounded = true;
            Col_GroundIsOneSided = true;
            AddMovement(0, gravity * Time.fixedDeltaTime * 1f);
        }
        else
        {
            Col_GroundIsOneSided = false;
        }

        LastOneSidedGroundPoint = CurrentOneSidedGroundPoint;

        DefaultPhysicsStep();
        if (OnPhysicsStep != null)
        {
            OnPhysicsStep(this);
        }

        ClampSpeed();
        Movement += externalMovement * Time.fixedDeltaTime;
        externalMovement = Vector2.zero;
        Movement += velocity * Time.fixedDeltaTime;
        //Debug.Log("Step" + Movement);
        rb.MovePosition(rb.position + Movement);
    }

    public float GroundFriction = 0f;
    public bool prevGrounded = false;

    private void DefaultPhysicsStep()
    {
        if (ignoreFloor)
        {
            if (Col_ceiling)
            {
                ignoreFloor = false;
                leftGround = false;
            }
            if (Col_isGrounded)
            {
                if (leftGround)
                {
                    ignoreFloor = false;
                    leftGround = false;
                }
                else
                {
                    leftGround = true;
                }
            }
        }
        if (Col_isGrounded)
        {
            if (!prevGrounded)
            {
                OnLanding.Invoke();
            }
            if (!Col_GroundIsOneSided)
            {
                GroundProperties groundProp = TouchingGround[0].GetComponent<GroundProperties>();
                if (groundProp != null)
                    groundProp.OnStandOn(this);
            }
            if (!ignoreFloor)
            {
                velocity.x = velocity.x * GroundFriction;
            }
        }
        else
        {
            velocity += Vector2.down * gravity * gravityMultiplier * Time.fixedDeltaTime;
        }
        prevGrounded = Col_isGrounded;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + Vector3.up * GroundCheckPoint, GroundCheckRadius);
        Gizmos.DrawWireSphere(transform.position + Vector3.up * CeilingCheckPoint, 0.06f);
        Gizmos.DrawWireSphere(transform.position + Vector3.up * CeilingCheckPoint / 2 - Vector3.right * SideCheckPoint, 0.06f);
        Gizmos.DrawWireSphere(transform.position + Vector3.up * CeilingCheckPoint / 2 + Vector3.right * SideCheckPoint, 0.06f);
        Gizmos.DrawWireSphere(transform.position - Vector3.right * SideCheckPoint + Vector3.down * fallCheckPoint, 0.06f);
        Gizmos.DrawWireSphere(transform.position + Vector3.right * SideCheckPoint + Vector3.down * fallCheckPoint, 0.06f);
        if (Col_GroundIsOneSided)
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position + Vector3.down * OneSidedGroundPoint, 0.06f);
    }
    public UnityEvent OnLanding;
}
public class CollisionPoint2D
{
    /// <summary>
    /// Collided this frame
    /// </summary>
    public bool Collided;
    /// <summary>
    /// Collided last frame
    /// </summary>
    public bool CollidedLastUpdate;
    /// <summary>
    /// How long has it been since the last collision state change in seconds
    /// </summary>
    public float EchoTime;
    /// <summary>
    /// How many times TestCollision has been called since the last collision state
    /// </summary>
    public float EchoTicks;
    /// <summary>
    /// Array of collisions had last update
    /// </summary>
    public Collider2D[] Collisions;

    Transform parent;
    Vector2 position;
    float radius;
    LayerMask Layers;
    ContactFilter2D filter;

    public CollisionPoint2D(Transform parent, Vector2 position, float radius, LayerMask layers, int concurrentCollisions)
    {
        this.parent = parent;
        this.position = position;
        this.radius = radius;
        filter = new ContactFilter2D();
        filter.SetLayerMask(layers);
        this.Collisions = new Collider2D[concurrentCollisions];
    }
    public bool TestCollision(float DeltaTime)
    {
        CollidedLastUpdate = Collided;
        Collided = Physics2D.OverlapCircle((Vector2)parent.position + position, radius, filter, Collisions) > 0;
        if (CollidedLastUpdate != Collided)
        {
            EchoTime = 0;
            EchoTicks = 0;
        }
        else
        {
            EchoTime += DeltaTime;
            EchoTicks++;
        }
        return Collided;
    }
    public void DrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)parent.position + position, radius);
    }

}
