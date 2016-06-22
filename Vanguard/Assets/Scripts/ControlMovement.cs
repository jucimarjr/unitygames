using UnityEngine;
using System.Collections;

public class ControlMovement : MonoBehaviour {
    public float Velocity;
    Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.velocity += Vector2.up * Velocity;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            body.velocity += Vector2.down * Velocity;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity += Vector2.left * Velocity;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity += Vector2.right * Velocity;
        }
        else
        {
            GetComponent<AutoMovement>().SetAuto();
        }
    }
}
