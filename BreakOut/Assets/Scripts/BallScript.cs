using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    public float velocity;
    public Vector3 InitialPosition;
    public Lifes life;
    Rigidbody2D body;
    Score score;
    // Use this for initialization
    void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
        body = GetComponent<Rigidbody2D>();
        InitialPosition = transform.position;
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBall()
    {
        transform.position = InitialPosition;
        float angle = 45;
        float dirx = velocity * Mathf.Cos(angle * Mathf.Deg2Rad);
        float diry = velocity * Mathf.Sin(angle * Mathf.Deg2Rad);
        body.velocity = new Vector2(dirx, diry);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            life.ReduceLife();
            if (life.lifes > 0)
                SpawnBall();
            else
                Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            GetComponent<AudioSource>().Play();
            score.UpdateScore(100);
            Destroy(collision.gameObject);
            if (GameObject.Find("Blocks").transform.childCount <= 1)
            {
                life.gameOver.SetActive(true);
                life.gameOver.GetComponent<GameOver>().Win();
                Destroy(gameObject);
            }
        }
    }

    public void ReflectVelocity()
    {
        body.velocity = new Vector2(body.velocity.x + Random.Range(-1, 1), -body.velocity.y);
    }
}
