using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDie : MonoBehaviour
{
    public int Lifes;
    public GameObject explosion;
    public float SpawnTime;
    public Text gameOver;
    public Text LifesText;
    Vector3 SpawnPosition;
    public GameObject PauseMenu;
    // Use this for initialization
    void Start()
    {
        SpawnPosition = transform.position;
        LifesText.text = "Lifes: " + Lifes;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Die()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<ShootScript>().CanShoot = false;
        yield return new WaitForSeconds(SpawnTime);
        if (Lifes >= 0) Respawn();
        else GameOver();
    }

    void Respawn()
    {
        transform.position = SpawnPosition;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<ShootScript>().CanShoot = true;
        GetComponent<ShootScript>().StartCoroutine("Shoot");
    }

    public void GameOver()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<ShootScript>().CanShoot = false;
        gameOver.text = "You Lose";
        PauseMenu.SetActive(true);
    }

    public void Win()
    {
        PauseMenu.SetActive(true);
        gameOver.text = "You Win";
        GetComponent<ShootScript>().CanShoot = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            Lifes--;
            LifesText.text = "Lifes: " + Lifes;
            Instantiate(explosion, transform.position, Quaternion.identity);
            StartCoroutine(Die());
        }
    }
}
