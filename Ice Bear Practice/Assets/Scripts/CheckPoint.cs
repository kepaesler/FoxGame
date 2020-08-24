using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //public LevelManager level = new LevelManager();

    private Vector2 spawn;

    void Start()
    {
        spawn = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //change respawn point
            //level.ChangeSpawn(spawn);
            Debug.Log("change");
        }
    }
}
