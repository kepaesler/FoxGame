using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 100;
    public int curHP;

    bool isColliding = false;

    public HPBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        healthbar.SetMaxHealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            //to prevent from double counting due to hitboxes
            if (isColliding)
                return;
            isColliding = true;
            TakeDamage(20);
        }
    }

    void TakeDamage(int dmg)
    {
        curHP -= dmg;
        healthbar.SetHealth(curHP);
    }
}
