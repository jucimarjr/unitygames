using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float velocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		float dist = pos.x - transform.position.x;
		dist = (dist / 100) * velocity;
		transform.Translate(dist, 0, 0);
	}



}
