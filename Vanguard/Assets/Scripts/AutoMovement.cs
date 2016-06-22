using UnityEngine;
using System.Collections;

public class AutoMovement : MonoBehaviour
{
    public Vector2 MovementDirection;
    public float velocity;
    Rigidbody2D body;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        SetAuto();
    }

    public void SetAuto()
    {
        body.velocity = Movement();
    }

    public void ChangeDirection(Vector2 Direction)
    {
        MovementDirection = Direction;
        SetAuto();
    }

    public void ChangeAngle(float Angle)
    {
        body.rotation = Angle;
    }

    public Vector2 Movement()
    {
        return MovementDirection.normalized * velocity;
    }
}