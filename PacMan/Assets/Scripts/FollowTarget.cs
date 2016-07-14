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

    public bool CanChange = true;

    //public Direction nextDirection;
    public float distance;
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

    // Update is called once per frame
    void Update()
    {
        base.Update();
        distance = Vector2.Distance(transform.position, TilePosition.ToWorldPoint());
        if (Vector2.Distance(transform.position, TilePosition.ToWorldPoint()) < ChangeDistance && CanChange)
        {
            Direction newDirection = VerifyMinDistance(VerifyAvaliableDirections());
            if (direction != newDirection)
            {
                CanChange = false;
                direction = newDirection;
                ChangeDirection(direction);
            }
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
    }

    void ChangeDirection(Direction direction)
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
        transform.position = TilePosition.ToWorldPoint();
        body.velocity = GetDirectionVector(direction) * velocity;
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
                    Debug.DrawLine(Target, newTile.ToWorldPoint());
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
                    Debug.DrawLine(Target, newTile.ToWorldPoint());
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
                    Debug.DrawLine(Target, newTile.ToWorldPoint());
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
                    Debug.DrawLine(Target, newTile.ToWorldPoint());
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

    List<Direction> VerifyAvaliableDirections()
    {
        List<Direction> DirectionsAvaliable = new List<Direction>();
        switch (direction)
        {
            case Direction.Up:
                //Verificar direcoes disponiveis menos Up;
                if (VerifyDirection(Vector2.right, 1f))
                    DirectionsAvaliable.Add(Direction.Right);
                if (VerifyDirection(Vector2.up, 1f))
                    DirectionsAvaliable.Add(Direction.Up);
                if (VerifyDirection(Vector2.left, 1f))
                    DirectionsAvaliable.Add(Direction.Left);
                break;
            case Direction.Left:
                //Verificar direcoes disponiveis menos Right;
                if (VerifyDirection(Vector2.left, 1f))
                    DirectionsAvaliable.Add(Direction.Left);
                if (VerifyDirection(Vector2.down, 1f))
                    DirectionsAvaliable.Add(Direction.Down);
                if (VerifyDirection(Vector2.up, 1f))
                    DirectionsAvaliable.Add(Direction.Up);
                break;
            case Direction.Down:
                //Verificar direcoes disponiveis menos Down;
                if (VerifyDirection(Vector2.right, 1f))
                    DirectionsAvaliable.Add(Direction.Right);
                if (VerifyDirection(Vector2.left, 1f))
                    DirectionsAvaliable.Add(Direction.Left);
                if (VerifyDirection(Vector2.down, 1f))
                    DirectionsAvaliable.Add(Direction.Down);
                break;
            case Direction.Right:
                //Verificar direcoes disponiveis menos Left;
                if (VerifyDirection(Vector2.right, 1f))
                    DirectionsAvaliable.Add(Direction.Right);
                if (VerifyDirection(Vector2.down, 1f))
                    DirectionsAvaliable.Add(Direction.Down);
                if (VerifyDirection(Vector2.up, 1f))
                    DirectionsAvaliable.Add(Direction.Up);
                break;
        }
        return DirectionsAvaliable;
    }

    public void SetTarget(Vector2 target)
    {
        Target = target;
    }

    public void SetScatter()
    {
        Target = ScatterTarget;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GhostHouse"))
        {
            SetTarget(HouseExit);
        }
    }
}
