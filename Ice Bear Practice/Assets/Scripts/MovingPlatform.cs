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

    private int flip = 1;

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
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, pos2) < 1.0f)
        {
            flip = -1;
        }
        else if (Vector3.Distance(transform.position, pos1) < 1.0f)
        {
            flip = 1;
        }
        transform.position += (flip * velocity * Time.deltaTime);
    }
}
