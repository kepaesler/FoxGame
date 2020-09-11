using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager1 : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawnPosition = new Vector2(-5, -1);

    public Transform playerTransform;

    //used to respawn falling platforms
    private bool platforms = false;

    //used to reset health
    [SerializeField]
    private PlayerHP playerhealth;

    // Update is called once per frame
    void FixedUpdate()
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
        //reset health
        playerhealth.setMaxHP();

        StartCoroutine(platformReset());

    }

    IEnumerator platformReset()
    {
        platforms = true;
        yield return new WaitForSeconds(1);
        Debug.Log("waited");
        platforms = false;
    }


    public void ChangeSpawn(Vector2 spawn)
    {
        spawnPosition = spawn;
    }

    public bool getPlatforms()
    {
        return platforms;
    }

}
