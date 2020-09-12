using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


//class that keeps track of data to save
public class PlayerCurrentData : MonoBehaviour
{
    public static bool load = false;

    public int hp { get; set; }

    public int level;

    [SerializeField]
    private PlayerHP playerhealth;

    [SerializeField]
    private LevelLoading loading;

    void Start()
    {
        if (load)
        {
            LoadPlayer();
        }
    }

    public void updateLevel()
    {
        level++;
    }

    public void SavePlayer()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        Debug.Log(level);
        loading.Load(level);

        playerhealth.setHP(data.hp);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
