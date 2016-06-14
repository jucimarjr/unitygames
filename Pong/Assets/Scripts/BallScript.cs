using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    Rigidbody2D body;
    Score score;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        score = GameObject.FindObjectOfType<Score>();
        StartBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartBall()
    {
        transform.position = new Vector3(0, 0, 0);

        float angle = 45;
        float force = 5;
        float dirx = force * Mathf.Cos(angle * Mathf.Deg2Rad);
        float diry = force * Mathf.Sin(angle * Mathf.Deg2Rad);
        body.velocity = new Vector2(dirx, diry);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Wall"))
        {
            body.velocity = body.velocity.normalized * (body.velocity.magnitude + 0.2f);
        }else if (coll.gameObject.CompareTag("Limit"))
        {            
            if (transform.position.y > 0)
            {
                score.UpdateScoreLeft();
            }
            else
            {
                score.UpdateScoreRight();
            }
            StartBall();
        }
        coll.gameObject.GetComponent<AudioSource>().Play();
    }
}
