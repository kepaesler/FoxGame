using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private Collider2D m_Collider;

    [SerializeField]
    private Dialogue dial;

    [SerializeField]
    private string dialog;

    [SerializeField]
    private List<string> next;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dial.changeDialogue(dialog);
            dial.changeDialogueList(next);
            Destroy(this.gameObject);
        }
    }
}
