using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    bool isColliding = false;

    private Vector2 pos1;
    private Vector2 pos2;
    private Vector2 posDiff = new Vector2(0, 0.5f);
    public float speed = 1.0f;

    void Start()
    {
        pos1 = transform.position;
        pos2 = pos1 + posDiff;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //to prevent coin from double counting due to hitboxes
            if (isColliding)
                return;
            isColliding = true;

            ScoreManager.instance.ChangeScore(coinValue);
        }
    }

    void Update()
    {
        isColliding = false;
        transform.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
