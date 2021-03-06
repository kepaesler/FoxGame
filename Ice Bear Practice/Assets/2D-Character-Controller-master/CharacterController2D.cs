using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .05f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    //wallsliding variables
    bool isTouchingFront = false;
    public Transform frontCheck;
    bool wallSliding = false;
    public float wallSlidingSpeed;

    //wall jumping variables
    bool wallJumping = false;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime = 0.5f;

    //balloon variables
    //once balloon is found, balloon power = true
    public bool balloonPower = false;
    //true if currently using balloon
    private bool curBalloon = false;
    //to prevent using balloon more than once
    private bool usedBalloon = false;

    private Vector2 balloonVector = new Vector2(0, 2);

    public UnityEvent OnBalloonEvent;
    public UnityEvent OnBalloonEmptyEvent;


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        //touchingfrontcheck
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, k_GroundedRadius, m_WhatIsGround);

        if (isTouchingFront && !m_Grounded)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }
    }


    public void Move(float move, bool crouch, bool jump, bool balloon)
    {
        if (!balloonPower)
        {
            balloon = false;
        }
        // player cannot move while using balloon
        if (curBalloon)
        {
            OnBalloonEvent.Invoke();
            m_Rigidbody2D.velocity = balloonVector;
            return;
        }

        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {

            // If crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            //change y velocity if wallsliding  
            if (wallSliding)
            {
                targetVelocity = new Vector2(move * 10f, Mathf.Clamp(m_Rigidbody2D.velocity.y, -wallSlidingSpeed, float.MaxValue));
            }
            else if (wallJumping)
            {
                Debug.Log("walljump");
                targetVelocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y);
                return;
            }
            //If player should wall jump
            if (wallSliding && jump)
            {
                wallJumping = true;
                Invoke("wallJumpFalse", wallJumpTime);
                int i = 1;
                if (m_FacingRight)
                {
                    i = -1;
                }
                //make wall jump fixed so remove previous velocity
                targetVelocity = new Vector2(0, 0);
                m_Rigidbody2D.velocity = targetVelocity;

                m_Rigidbody2D.AddForce(new Vector2(xWallForce * i, m_JumpForce));
                Flip();
                return;
            }

            //if player can use balloon
            if (balloon && !usedBalloon && !m_Grounded)
            {
                targetVelocity = new Vector2(0, 2);
                curBalloon = true;
                usedBalloon = true;

                Debug.Log("balloon2");
                StartCoroutine(waitBalloon());
            }
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }

        //reset balloon useage once player has reached the ground again
        if (m_Grounded)
        {
            usedBalloon = false;

        }

    }

    IEnumerator waitBalloon()
    {
        yield return new WaitForSeconds(2.5f);
        Debug.Log("waited");

        OnBalloonEmptyEvent.Invoke();
        curBalloon = false;
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void wallJumpFalse()
    {
        wallJumping = false;
    }


}
