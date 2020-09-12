using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        //loads level
        PlayerData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.level);
        PlayerCurrentData.load = true;
    }

    public void quitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
