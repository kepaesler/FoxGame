using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background2 : MonoBehaviour
{
    public GameObject player;
    public Vector3 move;
    void Update()
    {
        // background matches the player's position
        this.transform.position = player.transform.position + move;
    }
}
