using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MazeMovement : MonoBehaviour {
    public TilePosition TilePosition;
    public Color LineColor;
    public enum Direction
    {
        Up, Down, Left, Right
    }
    public Direction direction;
    // Use this for initialization
    protected void Start () {
        TilePosition = new TilePosition();
	}
	
	// Update is called once per frame
	protected void Update () {
        TilePosition.x = Mathf.FloorToInt(transform.position.x);
        TilePosition.y = Mathf.FloorToInt(transform.position.y);
    }

    public bool VerifyWallTile()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector3.forward, 1f);
        foreach(RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return false;
            }
        }
        return true;
    }

    public void FitToTile(Vector2 tile)
    {
        if (!VerifyWallTile())
        {
            Debug.Log("Wall");
            float difx = transform.position.x - (tile.x + 0.5f);
            float dify = transform.position.y - (tile.y + 0.5f);
            if(difx >= 0)
            {
                if(dify >= 0)
                {
                    if(difx > dify)
                    {
                        //To up
                        direction = Direction.Up;
                    }else
                    {
                        //To right
                        direction = Direction.Right;
                    }
                }else
                {
                    if(difx > -dify)
                    {
                        //To right
                        direction = Direction.Right;
                    }
                    else
                    {
                        //To down
                        direction = Direction.Down;
                    }
                }
            }else
            {
                if (dify >= 0)
                {
                    if (-difx > dify)
                    {
                        //To up
                        direction = Direction.Up;
                    }
                    else
                    {
                        //To left
                        direction = Direction.Left;
                    }
                }
                else
                {
                    if (-difx > -dify)
                    {
                        //To left
                        direction = Direction.Left;
                    }
                    else
                    {
                        //To down
                        direction = Direction.Down;
                    }
                }
            }
            transform.position = PositionWithOffset(1);
        }
        else
        {
            transform.position = TilePosition.ToWorldPoint();
        }
    }


    public bool VerifyDirection(Vector2 direction, float distance)
    {
        Debug.DrawLine(transform.position, (transform.position + (Vector3)direction * distance), LineColor);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, distance);
        foreach(RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Wall"))
                {
                    return false;
                }
                else if (hit.collider.CompareTag("Tunnel"))
                {
                    transform.position = Vector3.Reflect(transform.position, Vector3.right);
                }
                else if (hit.collider.CompareTag("HouseDoor"))
                {
                    if (direction == Vector2.down)
                    {
                        return false;
                    }
                }
            }        
        }
        return true;
    }

    public List<Direction> VerifyAvaliableDirections()
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

    public Vector2 GetDirectionVector(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Vector2.up;
            case Direction.Down:
                return Vector2.down;
            case Direction.Left:
                return Vector2.left;
            case Direction.Right:
                return Vector2.right;
            default:
                return Vector2.zero;
        }
    }

    public Vector2 PositionWithOffset(int offset)
    {
        switch (direction)
        {
            case Direction.Up:
                return Vector2.up * offset + TilePosition.ToWorldPoint();
            case Direction.Down:
                return Vector2.down * offset + TilePosition.ToWorldPoint();
            case Direction.Left:
                return Vector2.left * offset + TilePosition.ToWorldPoint();
            case Direction.Right:
                return Vector2.right * offset + TilePosition.ToWorldPoint();
            default:
                return Vector2.zero;
        }
    }
}

[Serializable]
public class TilePosition
{
    public int x;
    public int y;

    public Vector2 ToWorldPoint()
    {
        return new Vector2(x + 0.5f, y + 0.5f);
    }

    public static TilePosition ToTilePoint(Vector2 position)
    {
        TilePosition t = new TilePosition();
        t.x = Mathf.FloorToInt(position.x);
        t.y = Mathf.FloorToInt(position.y);
        return t;
    }
}
