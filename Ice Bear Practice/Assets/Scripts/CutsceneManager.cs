using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Playables;

using UnityEngine.UI;


public class CutsceneManager : MonoBehaviour
{
    private bool done = false;

    [SerializeField]
    private Dialogue dial;


    [SerializeField]
    private string dialogueText;

    [SerializeField]
    private PlayableDirector director;

    // Update is called once per frame
    void Update()
    {
        //if player is loading game dont run opening cutscene
        if (PlayerCurrentData.load)
        {
            director.Stop();

            //needed due to director stop bug
            dial.gameObject.SetActive(false);
            Debug.Log("dialogueLoadcheck");
            this.gameObject.SetActive(false);
        }

        //press space to continue 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (done || (dialogueText == ""))
            {
                director.Stop();
            }
            else
            {
                //change dialogue
                dial.changeDialogue(dialogueText);

                done = true;
            }
        }
    }
}
