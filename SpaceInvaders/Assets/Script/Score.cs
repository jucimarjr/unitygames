using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public Text ScoreText;
    public int score;
	// Use this for initialization
	void Start () {
        ScoreText.text = "Score: " + score;
    }
	
    public void AddScore()
    {
        score += 10;
        ScoreText.text = "Score: " + score;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
