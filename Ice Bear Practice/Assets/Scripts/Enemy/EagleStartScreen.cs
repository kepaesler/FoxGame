using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleStartScreen : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;

    [SerializeField]
    private Vector3 posDiff;

    [SerializeField]
    private Vector3 posDiff2;


    void Start()
    {
        pos1 = transform.position;
        pos2 = pos1 + posDiff;
        pos3 = pos1 + posDiff2;
        //Flip();
    }


    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, pos2) <= 25)
        {
            //transform.position = pos1;
            velocity = new Vector3(velocity.x, -velocity.y, 0);
        }
        else if (Vector3.Distance(transform.position, pos3) <= 25)
        {
            velocity = new Vector3(-velocity.x, -velocity.y, 0);
            Flip();
        }
        else if ((Vector3.Distance(transform.position, pos1) <= .01f))
        {
            velocity = new Vector3(-velocity.x, -velocity.y, 0);
            Flip();
        }
        transform.position += (velocity * Time.deltaTime);
    }

    private void Flip()
    {

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
