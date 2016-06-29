using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
    public int Lifes;
    public Text LifesText;
    public Text GameOverText;
    public Vector3 SpawnPointCameraRelative;
    public GameObject Explosion;
    public bool gameover = false;
    // Use this for initialization
    void Start()
    {
        Respawn();
        LifesText.text = ""+Lifes;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    void Explode()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Shoot>().enabled = false;
        GameObject NewExplosion = (GameObject)Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    void Respawn()
    {
        transform.position = Camera.main.ViewportToWorldPoint(SpawnPointCameraRelative);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Shoot>().enabled = true;
    }

    void ReduceLife()
    {
        Lifes--;
        LifesText.text = ""+Lifes;
        if (Lifes < 0)
            Lifes = 0;
    }

    void GameOver()
    {
        gameover = true;
        GameOverText.text = "GameOver";
        
    }

    public IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("BulletEnemy"))
        {
            if (collision.gameObject.CompareTag("BulletEnemy")) Destroy(collision.gameObject);
            ReduceLife();
            Explode();
            if(Lifes <= 0)
            {
                GameOver();
                yield break;
            }
            yield return new WaitForSeconds(1);
            Respawn();
        }
    }
}