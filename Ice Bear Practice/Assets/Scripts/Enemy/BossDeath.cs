using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    [SerializeField]
    private PlayerHP enemyHP;

    [SerializeField]
    private EndGame end;

    // Update is called once per frame
    void Update()
    {
        if(enemyHP.curHP <= 0)
        {
            end.bossDead = true;
        }
    }
}
