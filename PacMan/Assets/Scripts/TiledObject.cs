using UnityEngine;
using System.Collections;
using System;

public class MazeMovement : MonoBehaviour {
    public TilePosition TilePosition;
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


    protected bool VerifyDirection(Vector2 direction, float distance)
    {
        Debug.DrawLine(transform.position, (transform.position + (Vector3)direction * distance));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance);
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
        }
        return true;
    }

    protected Vector2 GetDirectionVector(Direction direction)
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
}
