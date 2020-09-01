using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private LevelManager1 level;

    private Vector2 spawn;

    private Collider2D m_Collider;

    void Start()
    {
        spawn = transform.position;
        m_Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //change respawn point
            level.ChangeSpawn(spawn);
            //disable collider after to prevent weird animations
            m_Collider.enabled = !m_Collider.enabled;
            //do checkpoint animation

        }
    }
}
