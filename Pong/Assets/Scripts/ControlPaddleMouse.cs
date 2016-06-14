using UnityEngine;
using System.Collections;

public class ControlPaddleMouse : MonoBehaviour {
    PaddleScript script;
	// Use this for initialization
	void Start () {
        script = GetComponent<PaddleScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1)
        {
            //Testar no Unity usando o mouse
            if (Input.GetMouseButton(0))
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if ((script.Side == PaddleScript.Paddle.Right && pos.y < 0) || (script.Side == PaddleScript.Paddle.Left && pos.y > 0))
                {
                    float dist = pos.x - transform.position.x;
                    dist = (dist / 100) * script.velocity;

                    transform.Translate(dist, 0, 0);
                }

            }
        }
    }
}
