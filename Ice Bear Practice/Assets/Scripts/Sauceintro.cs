using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauceintro : MonoBehaviour
{
    private Collider2D m_Collider;

    [SerializeField]
    private Dialogue dial;

    [SerializeField]
    private string dialog;
    private float transitionTime = 2.5f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dial.changeDialogue(dialog, transitionTime);
            Destroy(this.gameObject);
        }
    }
}
