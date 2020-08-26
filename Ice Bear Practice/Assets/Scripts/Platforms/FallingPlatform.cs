using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    //how fast to shake
    private Vector3 velocity = new Vector3(1, 0, 0);

    //how fast to fall
    private Vector3 fallVelocity = new Vector3(0, -10, 0);

    private Vector3 pos1;
    private Vector3 pos2;

    //how much to shake 
    private Vector3 posDiff = new Vector3(0.15f, 0, 0);

    //used to shake back and forth
    private int flip = 1;

    private bool falling = false;

    private bool shaking = false;

    private bool onPlatform = false;

    private float shakeTime = 1.0f;

    void Start()
    {
        pos1 = transform.position;
        pos2 = pos1 + posDiff;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onPlatform = true;

            if (!falling)
                StartCoroutine(ExecuteAfterTime1(shakeTime));

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.SetParent(null);
            onPlatform = false;
        }
    }

    void FixedUpdate()
    {
        if (shaking)
        {
            shake();
        }
        else if (falling)
        {
            fall();
        }
    }

    void shake()
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
    }

    IEnumerator ExecuteAfterTime1(float time)
    {
        Debug.Log("time");
        if (shaking)
            yield break;

        shaking = true;

        yield return new WaitForSeconds(time);

        //player is still on falling platform
        if (onPlatform)
            player.SetParent(transform);

        falling = true;

        shaking = false;
    }

    void fall()
    {
        transform.position += (fallVelocity * Time.deltaTime);
    }
}
