using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector director;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            director.Stop();
        }
    }
}
