using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public GameObject player;

    void Update()
    {
        // background matches the player's position
        this.transform.position = player.transform.position;
    }
}
