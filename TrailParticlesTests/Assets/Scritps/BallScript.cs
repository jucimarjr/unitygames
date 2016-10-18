using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
    Rigidbody2D body;
    public float force;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(Vector2.right * force);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
