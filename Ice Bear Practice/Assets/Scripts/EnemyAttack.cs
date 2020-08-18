using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHP HP;
    bool isColliding = false;

    public int enemyPower;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //to prevent coin from double counting due to hitboxes
            if (isColliding)
                return;
            isColliding = true;

            HP.TakeDamage(enemyPower);
        }
    }

    void Update()
    {
        isColliding = false;
    }
}
