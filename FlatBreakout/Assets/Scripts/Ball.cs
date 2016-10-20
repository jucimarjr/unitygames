using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{

	Rigidbody2D body;
	Score score;
	public float velocity;


	// Use this for initialization
	void Start () {

		body = GetComponent<Rigidbody2D> ();
		score = GetComponent<Score>();
		Spawn ();
	
	}

	void Spawn(){
		transform.position = new Vector3 (0, 0, 0);

		float angle = 45;
		float dirX = velocity * Mathf.Cos (angle * Mathf.Deg2Rad);
		float dirY = velocity * Mathf.Sin (angle * Mathf.Deg2Rad);

		body.velocity = new Vector2 (dirX, dirY);
	
	}


	public void OnCollisionExit2D(Collision2D collision)
	{
		
		Debug.Log (collision.gameObject + "");

		body.velocity = body.velocity.normalized * ( body.velocity.magnitude + 0.2f );

		if (collision.gameObject.CompareTag("WallTag"))
		{
			
			collision.gameObject.GetComponent<AudioSource>().Play();
		}

		if (collision.gameObject.CompareTag("WallDownTag"))
		{

			collision.gameObject.GetComponent<AudioSource>().Play();
			Destroy(gameObject);
			score.GameOver ();
		}

		if (collision.gameObject.CompareTag ("BlockTag")) {
			GetComponent<AudioSource>().Play();
			Destroy (collision.gameObject);
			body.velocity = new Vector2(body.velocity.x + Random.Range(-1, 1), -body.velocity.y);
			score.UpdateScore (10);

			if (GameObject.Find("Blocks").transform.childCount <= 1)
			{
				Destroy(gameObject);
				score.GameOver ();
			}


		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
