using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowTarget : MazeMovement
{
    public Vector2 Target;
    public Vector2 ScatterTarget;
    public Vector2 StartPoint;
    public Vector2 HouseExit;
    public float velocity;
    Rigidbody2D body;

    public GameObject TargetLine;
    public bool DrawTargetLine;

    public bool CanChange = true;

    //public Direction nextDirection;
    float distance;
    public float ChangeDistance;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        //Time.timeScale = 0.05f;
        base.Start();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        body.velocity = GetDirectionVector(direction) * velocity;
        StartPoint = transform.position;
    }

    void OnEnable()
    {
        transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f);
        if(body != null)
            RevertDirection();
        if (anim != null)
            SetAnim();
    }

    void OnDisable()
    {
        body.velocity = -body.velocity;
    }

    void SetAnim()
    {
        Mode mode =  GetComponent<GhostModes>().mode;
        if(mode != Mode.Eyes)
        {
            switch (direction)
            {
                case Direction.Right:
                    anim.SetTrigger("right");
                    break;
                case Direction.Left:
                    anim.SetTrigger("left");
                    break;
                case Direction.Up:
                    anim.SetTrigger("up");
                    break;
                case Direction.Down:
                    anim.SetTrigger("down");
                    break;
            }
        }        
    }

    void ChooseDirectionMove()
    {
        Direction newDirection = VerifyMinDistance(VerifyAvaliableDirections());
        if (direction != newDirection)
        {
            CanChange = false;
            direction = newDirection;
            ChangeDirection(direction);
        }
    }

    public void ChangeDrawLine()
    {
        DrawTargetLine = !DrawTargetLine;
        TargetLine.SetActive(DrawTargetLine);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (DrawTargetLine)
        {
            DrawLineTarget();
        }

        distance = Vector2.Distance(transform.position, TilePosition.ToWorldPoint());
        if (Vector2.Distance(transform.position, TilePosition.ToWorldPoint()) < ChangeDistance && CanChange)
        {
            ChooseDirectionMove();
        }
        if (distance > 0.4f)
        {
            CanChange = true;
        }
        
        else
        if (!VerifyDirection(GetDirectionVector(direction), 0.5f))
        {
            body.velocity = Vector2.zero;
        }
        
        if(body.velocity == Vector2.zero)
        {
            Direction newDirection = VerifyMinDistance(VerifyAvaliableDirections());
            CanChange = false;
            direction = newDirection;
            ChangeDirection(direction);
        }
    }

    void ChangeDirection(Direction direction)
    {
        
        SetAnim();
        transform.position = TilePosition.ToWorldPoint();
        body.velocity = GetDirectionVector(direction) * velocity;
    }

    void DrawLineTarget()
    {
        Vector3 dir = Target - (Vector2)transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        TargetLine.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        float dist = 1.65f * Vector3.Distance(Target, (Vector2)transform.position);
        TargetLine.transform.localScale = new Vector3(dist, 0.1f, 0);
    }

    Direction VerifyMinDistance(List<Direction> AvaliableDirections)
    {
        float MinDistance = 1000;
        float dist = 0;
        Direction chooseDirection = direction;
        TilePosition newTile;
        foreach (Direction testDirection in AvaliableDirections)
        {
            switch (testDirection)
            {
                case Direction.Right:
                    newTile = new TilePosition();
                    newTile.x = TilePosition.x;
                    newTile.y = TilePosition.y;
                    newTile.x += 1;
                    Debug.DrawLine(Target, newTile.ToWorldPoint(), LineColor);
                    dist = Vector2.Distance(Target, newTile.ToWorldPoint());
                    if (dist < MinDistance)
                    {
                        MinDistance = dist;
                        chooseDirection = Direction.Right;
                    }
                    break;
                case Direction.Left:
                    newTile = new TilePosition();
                    newTile.x = TilePosition.x;
                    newTile.y = TilePosition.y;
                    newTile.x -= 1;
                    Debug.DrawLine(Target, newTile.ToWorldPoint(), LineColor);
                    dist = Vector2.Distance(Target, newTile.ToWorldPoint());
                    if (dist < MinDistance)
                    {
                        MinDistance = dist;
                        chooseDirection = Direction.Left;
                    }
                    break;
                case Direction.Up:
                    newTile = new TilePosition();
                    newTile.x = TilePosition.x;
                    newTile.y = TilePosition.y;
                    newTile.y += 1;
                    Debug.DrawLine(Target, newTile.ToWorldPoint(), LineColor);
                    dist = Vector2.Distance(Target, newTile.ToWorldPoint());
                    if (dist < MinDistance)
                    {
                        MinDistance = dist;
                        chooseDirection = Direction.Up;
                    }
                    break;
                case Direction.Down:
                    newTile = new TilePosition();
                    newTile.x = TilePosition.x;
                    newTile.y = TilePosition.y;
                    newTile.y -= 1;
                    Debug.DrawLine(Target, newTile.ToWorldPoint(), LineColor);
                    dist = Vector2.Distance(Target, newTile.ToWorldPoint());
                    if (dist < MinDistance)
                    {
                        MinDistance = dist;
                        chooseDirection = Direction.Down;
                    }
                    break;
            }
        }
        return chooseDirection;
    }

    public void SetTarget(Vector2 target)
    {
        Target = target;
    }

    public void SetScatter()
    {
        Target = ScatterTarget;
    }

    public void RevertDirection()
    {
        switch (direction)
        {
            case Direction.Up:
                direction = Direction.Down;
                break;
            case Direction.Down:
                direction = Direction.Up;
                break;
            case Direction.Left:
                direction = Direction.Right;
                break;
            case Direction.Right:
                direction = Direction.Left;
                break;
        }
        body.velocity = GetDirectionVector(direction) * velocity;
    }


    public bool returning = false;
    public void ReturnHome()
    {
        if (!returning)
        {
            RevertDirection();
            returning = true;
            CanEnterHouse = true;
            anim.SetTrigger("eyes");
            Target = StartPoint;
            velocity = 10;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GhostHouse"))
        {
            SetTarget(HouseExit);
        }
    }
}
