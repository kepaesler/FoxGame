﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField]
    private LevelLoading load;

    [SerializeField]
    private PlayerMovement playerMove;

    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private Text dialogText;
    [SerializeField]
    private string dialog;
    [SerializeField]
    private float transitionTime = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMove.stop = true;
            dialogBox.SetActive(true);
            dialogText.text = dialog;
            StartCoroutine(dialogWait());
        }
    }

    IEnumerator dialogWait()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(transitionTime);
        load.LoadNextLevel();
    }
}
