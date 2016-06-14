using UnityEngine;
using System.Collections;

public class AIPaddleScript : MonoBehaviour {
    PaddleScript script;
    GameObject ball;
	// Use this for initialization
	void Start () {
        script = GetComponent<PaddleScript>();
        ball = GameObject.Find("Ball");
	}
	
	// Update is called once per frame
	void Update () {
	    if(script.Side == PaddleScript.Paddle.Left)
        {
            if(ball.transform.position.y > 0)
            {
                float dist = ball.transform.position.x - transform.position.x;

                dist = (dist / 70) * script.velocity;

                transform.Translate(dist, 0, 0);
            }
        }
	}
}