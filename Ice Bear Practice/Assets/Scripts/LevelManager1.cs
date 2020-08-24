using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager1 : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawnPosition = new Vector2(-5, -1);

    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        // if player falls below stage respawn
        if (playerTransform.position.y < -10)
        {
            respawn();
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
