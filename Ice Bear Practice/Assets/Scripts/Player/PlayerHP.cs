using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 100;
    public int curHP;


    public HPBar healthbar;

    [SerializeField]
    private LevelManager1 lvl;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        healthbar.SetMaxHealth(maxHP);
    }



    public void TakeDamage(int dmg)
    {
        curHP -= dmg;
        healthbar.SetHealth(curHP);
        if (curHP <= 0)
        {
            //respawn character
            lvl.respawn();
            healthbar.SetHealth(maxHP);
        }
    }
}
