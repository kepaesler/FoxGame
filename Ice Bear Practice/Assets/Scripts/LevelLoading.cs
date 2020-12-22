using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public PlayerCurrentData data;


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        data.updateLevel();
    }

    public void Load(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
