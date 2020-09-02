using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private LevelManager1 level;

    private Vector2 spawn;

    private Collider2D m_Collider;

    [SerializeField]
    private Dialogue dial;

    private string reached = "CheckPoint Reached!";
    private float transitionTime = 0.75f;

    private bool done = false;

    void Start()
    {
        spawn = transform.position;
        m_Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!done)
            {
                //change respawn point
                level.ChangeSpawn(spawn);
                //disable collider after to prevent weird animations
                m_Collider.enabled = !m_Collider.enabled;
                //do checkpoint animation?

                dial.changeDialogue(reached, transitionTime);
            }

            done = true;

        }
    }
}
