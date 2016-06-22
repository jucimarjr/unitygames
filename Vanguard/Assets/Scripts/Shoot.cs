using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public float velocity;
    public GameObject BulletPrefab;
	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("BulletPlayer"), LayerMask.NameToLayer("BulletPlayer"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("BulletPlayer"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Wall"), LayerMask.NameToLayer("BulletPlayer"));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            shoot(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            shoot(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            shoot(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            shoot(Vector2.down);
        }
	}

    public void shoot(Vector2 direction)
    {
        GameObject NewBullet = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        NewBullet.GetComponent<Rigidbody2D>().rotation = Vector2.Angle(Vector2.right, direction);
        NewBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * velocity + GetComponent<AutoMovement>().Movement();
    }
}