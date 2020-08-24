using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collide");
            collision.collider.transform.SetParent(transform);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("unCollide");
            collision.collider.transform.SetParent(null);
        }
    }

    void FixedUpdate()
    {
        transform.position += (flip * velocity * Time.deltaTime);
        if (Vector3.Distance(transform.position, pos2) < 0.01f)
        {
            flip = flip * -1;
        }
        else if (Vector3.Distance(transform.position, pos1) < 0.01f)
        {
            flip = flip * -1;
        }
        //transform.position += (flip * velocity * Time.deltaTime);
    }
}
