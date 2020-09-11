using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class that keeps track of data to save
public class PlayerCurrentData : MonoBehaviour
{

    public int hp { get; set; }

    public int level = 0;

    [SerializeField]
    private PlayerHP playerhealth;

    public void updateLevel()
    {
        level++;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        playerhealth.setHP(data.hp);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
