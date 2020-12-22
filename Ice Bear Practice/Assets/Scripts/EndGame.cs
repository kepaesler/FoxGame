using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private LevelLoading load;

    [SerializeField]
    private PlayerMovement playerMove;

    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private Text dialogText;
    [SerializeField]
    private string dialog;
    [SerializeField]
    private float transitionTime = 3f;

    public bool bossDead = false;

    Collider m_Collider;

    void Start()
    {
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        m_Collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (bossDead)
            {
                //m_Collider.enabled = false;
                playerMove.stop = true;
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                StartCoroutine(dialogWait());
            }
        }
    }

    IEnumerator dialogWait()
    {
        //Debug.Log("Waiting");
        yield return new WaitForSeconds(transitionTime);
        load.Load(0);
    }
}
