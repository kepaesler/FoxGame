using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    [SerializeField] private LayerMask m_WhatIsGround;
    //radius for front check
    const float k_GroundedRadius = .1f;

    bool isColliding = false;
    bool isTouchingFront = false;
    public Transform possumFrontCheck;

    private Vector2 posDiff = new Vector2(1.0f, 0);
    public float speed = 1.0f;

    private bool m_FacingRight = false;



    void FixedUpdate()
    {
        int i = 1;
        if (!m_FacingRight)
            i = -1;

        transform.Translate(i * posDiff * speed * Time.deltaTime);

        isTouchingFront = Physics2D.OverlapCircle(possumFrontCheck.position, k_GroundedRadius, m_WhatIsGround);

        if (isTouchingFront)
        {
            Flip();
        }
    }

    // called once per frame
    void Update()
    {
        isColliding = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //to prevent from double counting due to hitboxes
            if (isColliding)
                return;
            isColliding = true;

        }
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
}
