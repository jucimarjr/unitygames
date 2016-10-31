using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text scoreText;
    public Slider HealthBar;
	public GameObject gameOverImage, playButton, exitButton;
	int score;
    public bool running;

    // Use this for initialization
    void Start () {
        running = true;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateScore( int newScore ){
        HealthBar.value--;
        score = score + newScore;
		scoreText.text = score + "";
	}

	public void GameOver(){
        running = false;
		gameOverImage.SetActive (true);
		playButton.SetActive (true);
		exitButton.SetActive (true);
		
	}
}
