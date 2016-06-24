using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class EnemyDie : MonoBehaviour {
    public GameObject Explosion;
    ScoreControl Score;
	// Use this for initialization
	void Start () {
        Score = FindObjectOfType<ScoreControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            Score.AddScore(100);
            GameObject NewExplosion = (GameObject)Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
