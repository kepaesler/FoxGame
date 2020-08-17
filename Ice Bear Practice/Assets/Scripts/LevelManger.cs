using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{

    public Vector3 spawnPosition;

    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        // if player falls below stage respawn
        if(playerTransform.position.y < -10)
        {
            playerTransform.position = spawnPosition;
        }
    }
}
