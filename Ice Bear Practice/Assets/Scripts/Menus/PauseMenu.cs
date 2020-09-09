using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject pauseMenuUI;

    [SerializeField]
    private GameObject dialogue;

    private bool wasUsingDialogue = false;

    [SerializeField]
    private PlayableDirector director;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //cutscene dont pause
            if (director.state == PlayState.Playing)
            {
                return;
            }

            Debug.Log("ESCAPE");
            if (gamePaused)
            {
                resume();
                if (wasUsingDialogue)
                {
                    dialogue.SetActive(true);
                    wasUsingDialogue = false;
                }
            }
            else
            {
                pause();
                if (dialogue.active)
                {
                    dialogue.SetActive(false);
                    wasUsingDialogue = true;
                }
            }
        }
    }

    private void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

}
