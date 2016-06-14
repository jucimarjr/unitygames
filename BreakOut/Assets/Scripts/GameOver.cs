using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {
    public Text gameOverText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Win()
    {
        gameObject.SetActive(true);
        gameOverText.text = "You Win";
    }

    public void Lose()
    {
        gameObject.SetActive(true);
        gameOverText.text = "You Lose";
    }
}
