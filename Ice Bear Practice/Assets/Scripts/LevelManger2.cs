using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger2 : MonoBehaviour
{
    public static Vector2 spawnPosition;

    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        // if player falls below stage respawn
        if (playerTransform.position.y < -10)
        {
            playerTransform.position = spawnPosition;
        }
    }

    public void respawn()
    {
        playerTransform.position = spawnPosition;
    }

    public void ChangeSpawn(Vector2 spawn)
    {
        spawnPosition = spawn;
    }
}
