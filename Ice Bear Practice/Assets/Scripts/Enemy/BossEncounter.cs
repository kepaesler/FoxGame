using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEncounter : MonoBehaviour
{
    [SerializeField]
    private EnemyAI boss;

    [SerializeField]
    private GameObject bossHP;

    [SerializeField]
    private Dialogue dial;

   public void StartFight()
    {
        bossHP.SetActive(true);
        boss.hunting = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        dial.bossTrigger = true;
        this.gameObject.SetActive(false);
    }
}
