using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {
    public int DotsEated;
    public int Score;
    public Text ScoreText;
    public int GhostMult;
    // Use this for initialization
    void Start () {
        DotsEated = 0;
        Score = 0;
        AddScore(0);
        GhostMult = 100;
    }

    public void AddScore(int add)
    {
        Score += add;
        ScoreText.text = "Score: " + Score;
    }
}
