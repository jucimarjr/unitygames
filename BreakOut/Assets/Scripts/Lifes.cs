using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lifes : MonoBehaviour {
    public int lifes;
    public Text lifeText;
    public GameObject gameOver;
	// Use this for initialization
	void Start () {
        lifes = 3;
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReduceLife()
    {
        lifes--;
        lifeText.text = "Lifes: " + lifes;
        if(lifes <= 0)
        {
            gameOver.SetActive(true);
            GameObject.FindObjectOfType<GameOver>().Lose();
        }
    }
}