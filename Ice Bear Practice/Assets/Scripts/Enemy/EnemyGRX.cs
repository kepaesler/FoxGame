using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGRX : MonoBehaviour
{
    public AIPath path;

    // Update is called once per frame
    void Update()
    {
        if (path.desiredVelocity.x >= .1f)
        {
            transform.parent.localScale = new Vector3(-.1f, .1f, .1f);
            Debug.Log("right");
        }
        else if (path.desiredVelocity.x <= -.1f)
        {
            transform.parent.localScale = new Vector3(.1f, .1f, .1f);
            Debug.Log("left");
        }
    }
}
