using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonPower : MonoBehaviour
{
    [SerializeField]
    private CharacterController2D controller;

    [SerializeField]
    private string dialog;


    [SerializeField]
    private Dialogue dial;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.balloonPower = true;

            dial.changeDialogue(dialog);
            Destroy(this.gameObject);


        }
    }
}
