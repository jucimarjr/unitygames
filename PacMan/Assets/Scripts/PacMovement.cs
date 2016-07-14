using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PacMovement : MazeMovement
{
    

    public float velocity;

    [Range(0, 0.5f)]
    public float CornerDistance;

    Direction newDirection;

    Rigidbody2D body;

    public Text txt;
    // Use this for initialization
    void Start()
    {
        base.Start();
        body = GetComponent<Rigidbody2D>();
        body.velocity = velocity * GetDirectionVector(direction);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            VerifyChangeDirection(Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            VerifyChangeDirection(Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            VerifyChangeDirection(Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            VerifyChangeDirection(Direction.Right);
        }


        if (!VerifyDirection(GetDirectionVector(direction), 0.55f))
        {
            body.velocity = Vector2.zero;
            GetComponent<Animator>().speed = 0;
        }

        txt.text = "Pac-man Position: " + TilePosition.x + "," + TilePosition.y;
        txt.text += "\nTile Position: " + TilePosition.ToWorldPoint().ToString();
    }

    void VerifyChangeDirection(Direction newDirection)
    {
        if (newDirection != direction)
        {
            if (VerifyDirection(GetDirectionVector(newDirection), 0.55f))
            {
                if (direction == Direction.Right)
                {
                    float dist = (TilePosition.x + 0.5f) - transform.position.x;
                    if (dist < CornerDistance)
                    {
                        direction = newDirection;
                        transform.position = new Vector2(TilePosition.x + 0.5f, transform.position.y + GetDirectionVector(direction).y * Mathf.Abs(dist));
                        body.velocity = velocity * GetDirectionVector(direction);
                    }
                }
                else
                if (direction == Direction.Left)
                {
                    float dist = transform.position.x - (TilePosition.x + 0.5f);
                    if (dist < CornerDistance)
                    {
                        direction = newDirection;
                        transform.position = new Vector2(TilePosition.x + 0.5f, transform.position.y + GetDirectionVector(direction).y * Mathf.Abs(dist));
                        body.velocity = velocity * GetDirectionVector(direction);
                    }
                }
                else
                if (direction == Direction.Up)
                {
                    float dist = transform.position.y - (TilePosition.y + 0.5f);
                    if (dist < CornerDistance)
                    {
                        direction = newDirection;
                        transform.position = new Vector2(transform.position.x + GetDirectionVector(direction).x * Mathf.Abs(dist), TilePosition.y + 0.5f);
                        body.velocity = velocity * GetDirectionVector(direction);
                    }
                }
                else
                if (direction == Direction.Down)
                {
                    float dist = (TilePosition.y + 0.5f) - transform.position.y;
                    if (dist < CornerDistance)
                    {
                        direction = newDirection;
                        transform.position = new Vector2(transform.position.x + GetDirectionVector(direction).x * Mathf.Abs(dist), TilePosition.y + 0.5f);
                        body.velocity = velocity * GetDirectionVector(direction);
                    }
                }
            }
            switch (direction)
            {
                case Direction.Right:
                    body.rotation = 0;
                    break;
                case Direction.Left:
                    body.rotation = 180;
                    break;
                case Direction.Up:
                    body.rotation = 90;
                    break;
                case Direction.Down:
                    body.rotation = 270;
                    break;
            }

            GetComponent<Animator>().speed = 1;
        }
    }
}
