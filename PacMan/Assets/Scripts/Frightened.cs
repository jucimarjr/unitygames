using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Frightened : MonoBehaviour
{
    Rigidbody2D body;
    Animator anim;
    Vector2 direction;
    MazeMovement movement;
    public bool CanChange;
    public float distance;
    public float ChangeDistance;
    public float velocity;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        CanChange = true;
        movement = GetComponent<MazeMovement>();
    }

    void OnEnable()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("fright");
        if(movement == null)
            movement = GetComponent<MazeMovement>();
        direction = movement.GetDirectionVector(movement.direction);
        transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f);
        GetComponent<FollowTarget>().RevertDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tilePosition = new Vector2(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f);
        distance = Vector2.Distance(transform.position, tilePosition);
        if (distance < ChangeDistance && CanChange)
        {
            direction = SelectRandomDirection();
            CanChange = false;
            //movement.FitToTile();
            transform.position = tilePosition;
            body.velocity = direction * velocity;
            
            if (!movement.VerifyDirection(direction, 0.5f))
            {
                CanChange = true;
            }
        }
        if (distance > 0.4f)
        {
            CanChange = true;
        }
        /*
        if(!movement.VerifyDirection(direction, 0.5f))
        {
            body.velocity = direction * -velocity;
            transform.position = tilePosition;
            CanChange = true;
        }
        */
        if(body.velocity == Vector2.zero)
        {
            Vector2 newDirection = SelectRandomDirection();
            CanChange = false;
            direction = newDirection;
            //movement.FitToTile();
            transform.position = tilePosition;
            body.velocity = direction * velocity;

            if (!movement.VerifyDirection(newDirection, 0.5f))
            {
                CanChange = true;
            }
        }
    }

    Vector2[] VerifyReturnDirection()
    {
        if(direction == Vector2.left)
        {
            Vector2[] dirs = { Vector2.up, Vector2.left, Vector2.down };
            return dirs;
        }
        if (direction == Vector2.right)
        {
            Vector2[] dirs = { Vector2.up, Vector2.down, Vector2.right };
            return dirs;
        }
        if (direction == Vector2.up)
        {
            Vector2[] dirs = { Vector2.up, Vector2.left, Vector2.right };
            return dirs;
        }
        if (direction == Vector2.down)
        {
            Vector2[] dirs = { Vector2.left, Vector2.down, Vector2.right };
            return dirs;
        }else
        {
            Vector2[] dirs = { Vector2.left, Vector2.down, Vector2.right, Vector2.up };
            return dirs;
        }
    }

    Vector2 SelectRandomDirection()
    {
        Vector2[] dirs = VerifyReturnDirection();
        Vector2 SelectedDirection = dirs[Random.Range(0, 3)];

        if (movement.VerifyDirection(SelectedDirection, 0.5f))
        {
            return SelectedDirection;
        }
        else
        {
            foreach (Vector2 newDirection in dirs)
            {
                if (movement.VerifyDirection(newDirection, 0.5f))
                {
                    return newDirection;
                }
            }
        }
        return Vector2.zero;
    }
}
