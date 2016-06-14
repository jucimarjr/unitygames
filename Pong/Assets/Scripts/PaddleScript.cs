using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
    public float velocity;
    public enum Paddle
    {
        Right,
        Left
    }
    public Paddle Side;

    float t;
    // Use this for initialization
    void Start()
    {
        if(Side == Paddle.Left && NumberOfPlayers.players == 1)
        {
            GetComponent<AIPaddleScript>().enabled = true;
            GetComponent<ControlPaddleMouse>().enabled = false;
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

                    if ((Side == Paddle.Right && pos.y > 0) || (Side == Paddle.Left && pos.y < 0))
                    {
                        float dist = pos.x - transform.position.x;
                        dist = (dist / 100) * velocity;

                        transform.Translate(dist, 0, 0);
                    }
                }
            }
        }
    }
}
