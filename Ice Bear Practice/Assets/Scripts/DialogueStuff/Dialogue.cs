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

    [SerializeField]
    private bool hasNext = false;

    public List<string> next;
    public int i =0;

    public bool bossTrigger = false;
    public BossEncounter boss;

    //changes dialogue box and makes it visible (also stops player movement)
    public void changeDialogue(string desiredDialogue)
    {
        Debug.Log("dialoguecheck");
        playerMove.stop = true;
        this.gameObject.SetActive(true);
        dialogText.text = desiredDialogue;

    }

   public void changeDialogueList(List<string> desiredDialogue)
    {
        playerMove.stop = true;
        this.gameObject.SetActive(true);
        next = desiredDialogue;
        if(next.Count != 0)
            hasNext = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //get next dialogue or exit
            if (hasNext)
            {

                dialogText.text = next[i];
                i += 1; 
                if(i>= next.Count)
                {
                    hasNext = false;
                    if (bossTrigger)
                    {
                        boss.StartFight();
                    }
                }
            }
            else
            {
                playerMove.stop = false;
                this.gameObject.SetActive(false);
            }
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
