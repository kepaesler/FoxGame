using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunBackForth : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;

    private Vector3 pos1;
    private Vector3 pos2;

    [SerializeField]
    private Vector3 posDiff;

    [SerializeField]
    private int flip;

    void Start()
    {
        pos1 = transform.position;
        pos2 = pos1 + posDiff;
    }


    void FixedUpdate()
    {
        transform.position += (flip * velocity * Time.deltaTime);
        if (Vector3.Distance(transform.position, pos2) < 0.01f)
        {
            flip = flip * -1;
            Flip();
        }
        else if (Vector3.Distance(transform.position, pos1) < 0.01f)
        {
            flip = flip * -1;
            Flip();
        }

    }

    private void Flip()
    {

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
