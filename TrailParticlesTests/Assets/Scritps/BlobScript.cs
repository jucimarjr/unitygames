using UnityEngine;
using System.Collections;

public class BlobScript : MonoBehaviour
{
    public GameObject ExplosionPrefab, StarPrefab;
    public float velocity, teleportRange;
    Rigidbody2D body;
    SpriteRenderer sprite;
    bool CanJump, Alive;
    // Use this for initialization
    void Start()
    {
        Alive = true;
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        GetComponent<DoubleTap>().onDoubleTap += Teleport;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            if (touchPosition.x < 0.5)
            {
                sprite.flipX = true;
                body.velocity = new Vector2(-velocity, body.velocity.y);
            }
            else
            {
                sprite.flipX = false;
                body.velocity = new Vector2(velocity, body.velocity.y);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }

    }

    void Respawn()
    {
        transform.position = Vector3.zero;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Respawn();
        }
        else if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            Instantiate(StarPrefab);
        }
    }

    void Teleport(Vector2 touchPosition)
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(touchPosition);
        if (pos.y > transform.position.y + teleportRange)
        {
            transform.position = new Vector3(pos.x, transform.position.y + teleportRange);
        }
        else
        {
            transform.position = pos;
        }
    }
}
