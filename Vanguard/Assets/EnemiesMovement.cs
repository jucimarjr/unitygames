using UnityEngine;
using System.Collections;

public class EnemiesMovement : MonoBehaviour
{
    public float velocity;
    public Vector2 direction;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * velocity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction = -direction;
            GetComponent<Rigidbody2D>().velocity = direction.normalized * velocity;
        }
    }
}
