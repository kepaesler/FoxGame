using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


//class that keeps track of data to save
public class PlayerCurrentData : MonoBehaviour
{
    public static bool load = false;

    public List<string> sirchachasCollected = new List<string>();

    public int hp { get; set; }

    public int level;

    public int score { get; set; }

    [SerializeField]
    private ScoreManager manager;

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
        score = manager.score;
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

        //load sirchachas collected 
        sirchachasCollected = data.sirchachasCollected;

        //score
        Debug.Log(data.score);
        manager.ChangeScore(data.score);
    }
}
