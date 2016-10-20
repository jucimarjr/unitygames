using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text scoreText;
	public GameObject gameOverImage, playButton, exitButton;
	int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateScore( int newScore ){
		score = score + newScore;
		scoreText.text = score + "";
	}

	public void GameOver(){
		gameOverImage.SetActive (true);
		playButton.SetActive (true);
		exitButton.SetActive (true);
		
	}
}
