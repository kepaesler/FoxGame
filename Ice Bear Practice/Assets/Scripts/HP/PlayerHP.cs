using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 100;
    public int curHP { get; set; }

    public Text HPnumbers;

    public HPBar healthbar;

    [SerializeField]
    private LevelManager1 lvl;

    [SerializeField]
    private PlayerCurrentData data;

    //isPlayer = true if hp belongs to player, false if it belongs to enemy
    [SerializeField]
    private bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        /*
        curHP = maxHP;
        healthbar.SetMaxHealth(maxHP);
        //update save data
        if (isPlayer)
            data.hp = curHP;
            */
        setMaxHP();

        updateText();
    }

    public void setHP(int hp)
    {
        curHP = hp;
        healthbar.SetHealth(curHP);
        updateText();
        //update save data
        if (isPlayer)
            data.hp = curHP;
    }

    public void setMaxHP()
    {
        curHP = maxHP;
        healthbar.SetMaxHealth(maxHP);

        //update save data
        if (isPlayer)
            data.hp = curHP;
        updateText();
    }

    public void TakeDamage(int dmg)
    {
        curHP -= dmg;
        healthbar.SetHealth(curHP);
        updateText();
        if (curHP <= 0)
        {
            if (isPlayer)
            {
                //respawn character
                lvl.respawn();
                healthbar.SetHealth(maxHP);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        //update save data
        if (isPlayer)
            data.hp = curHP;
    }

    void updateText()
    {
        HPnumbers.text = curHP.ToString() + "/" + maxHP.ToString();
    }
}
