using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMove;

    //[SerializeField]
    //private GameObject dialogBox;

    [SerializeField]
    private Text dialogText;


    //changes dialogue box and makes it visible (also stops player movement)
    public void changeDialogue(string desiredDialogue)
    {
        Debug.Log("dialoguecheck");
        playerMove.stop = true;
        this.gameObject.SetActive(true);
        dialogText.text = desiredDialogue;

    }

    /*
    IEnumerator dialogWait()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(transitionTime);
        playerMove.stop = false;
        this.gameObject.SetActive(false);
    }
    */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //get next dialogue or exit
            playerMove.stop = false;
            this.gameObject.SetActive(false);
        }
    }

    public void resetDialogue()
    {
        //clears other dialogue
    }

    //adds a dialogue slide
    public void addDialogue(string desiredDialogue)
    {

    }
}
