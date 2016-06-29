using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreControl : MonoBehaviour {
    public int Score;
    public Text ScoreText;
	// Use this for initialization
	void Start () {
        Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddScore(int add)
    {
        Score += add;
        ScoreText.text = "" + Score;
    }
}
