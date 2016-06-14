using UnityEngine;
using System.Collections;

public class EnemieDie : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public GameObject ScoreText;
    // Use this for initialization
    void Start()
    {
        ScoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            GameObject.FindObjectOfType<Score>().AddScore();
            GameObject NewExplosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            GameObject.Find("Player").GetComponent<PlayerDie>().GameOver();
        }
    }
}
