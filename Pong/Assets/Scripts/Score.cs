using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {
    public Text TextScoreUp, TextScoreDown;
    public GameObject TopWin, TopLose, BottomWin, BottomLose;
    int ScoreUp, ScoreDown;
    bool GameOver;
	// Use this for initialization
	void Start () {
        GameOver = false;
        ScoreUp = 0;
        ScoreDown = 0;
	}

    public void UpdateScoreRight()
    {
        ScoreUp++;
        TextScoreUp.text = "" + ScoreUp;
        if (ScoreUp >= 10) WinUp();
    }

    public void UpdateScoreLeft()
    {
        ScoreDown++;
        TextScoreDown.text = "" + ScoreDown;
        if (ScoreDown >= 10) WinDown();
    }

    void WinUp()
    {
        GameObject.Find("Ball").SetActive(false);
        TopWin.SetActive(true);
        BottomLose.SetActive(true);        
        GameOver = true;
    }

    void WinDown()
    {
        GameObject.Find("Ball").SetActive(false);
        TopLose.SetActive(true);
        BottomWin.SetActive(true);
        GameOver = true;
    }
}
