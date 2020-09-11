﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 100;
    public int curHP { get; set; }


    public HPBar healthbar;

    [SerializeField]
    private LevelManager1 lvl;

    [SerializeField]
    private PlayerCurrentData data;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        healthbar.SetMaxHealth(maxHP);
        data.hp = curHP;
    }

    public void setHP(int hp)
    {
        curHP = hp;
        healthbar.SetHealth(curHP);
        data.hp = curHP;
    }

    public void setMaxHP()
    {
        curHP = maxHP;
        healthbar.SetMaxHealth(maxHP);
        data.hp = curHP;
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

        //update save data
        data.hp = curHP;
    }
}
