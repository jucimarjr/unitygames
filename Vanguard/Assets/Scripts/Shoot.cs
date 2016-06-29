using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public float velocity;
    public GameObject BulletPrefab;
    public bool CanShoot = false;
	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("BulletPlayer"), LayerMask.NameToLayer("BulletPlayer"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("BulletEnemy"), LayerMask.NameToLayer("BulletPlayer"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("BulletEnemy"), LayerMask.NameToLayer("Wall"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("BulletPlayer"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Wall"), LayerMask.NameToLayer("BulletPlayer"));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            shoot(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            shoot(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            shoot(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            shoot(Vector2.down);
        }

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if(touch.phase == TouchPhase.Began)
                {
                    Vector3 pos = Camera.main.ScreenToViewportPoint(touch.position);
                    if (pos.y < 0.5f)
                    {
                        if (pos.x > 0.5f)
                        {
                            shoot(Vector2.right);
                        }
                        else
                        {
                            shoot(Vector2.left);
                        }
                    }
                    else
                    {
                        if (pos.x > 0.5f)
                        {
                            shoot(Vector2.up);
                        }
                        else
                        {
                            shoot(Vector2.down);
                        }
                    }
                }                
            }        
        }
    }

    public void shoot(Vector2 direction)
    {
        GameObject NewBullet = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        NewBullet.GetComponent<Rigidbody2D>().rotation = Vector2.Angle(Vector2.right, direction);
        NewBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * velocity + GetComponent<AutoMovement>().Movement();
    }
}