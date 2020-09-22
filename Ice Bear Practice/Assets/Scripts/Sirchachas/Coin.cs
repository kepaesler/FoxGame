using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //[SerializeField]
    //private AllSirchachasSave sirchachasSave;

    [SerializeField]
    private PlayerCurrentData data;

    public int coinValue = 1;
    bool isColliding = false;

    private Vector2 pos1;
    private Vector2 pos2;

    [SerializeField]
    private Vector2 posDiff = new Vector2(0, 0.5f);
    public float speed = 1.0f;

    [SerializeField]
    private ParticleSystem squirtEffect;

    // used to make particle effect appear at the top of sirchacha bottle
    private float sirchachaHeight = 0.3f;

    private string ID;

    void Start()
    {
        ID = transform.position.sqrMagnitude + "-";
        if (data.sirchachasCollected.Contains(ID))
        {
            Debug.Log("Destroyed");
            Destroy(this.gameObject);
        }
        pos1 = transform.position;
        pos2 = pos1 + posDiff;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(.1f);
        if (data.sirchachasCollected.Contains(ID))
        {
            Debug.Log("Destroyed");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            squirtEffect.transform.position = transform.position + new Vector3(0, sirchachaHeight, 0);
            squirtEffect.Play();

            //to prevent coin from double counting due to hitboxes
            if (isColliding)
                return;
            isColliding = true;

            // count score
            ScoreManager.instance.ChangeScore(coinValue);

            //add to collected
            data.sirchachasCollected.Add(ID);

            //delete sirchacha
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        isColliding = false;
        transform.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
