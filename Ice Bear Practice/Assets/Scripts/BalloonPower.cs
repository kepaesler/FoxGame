using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPower : MonoBehaviour
{
    public CharacterController2D controller;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.balloonPower = true;
            Destroy(this.gameObject);
        }
    }
}
