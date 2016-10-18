using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeController : MonoBehaviour {
    public int PacLifes;
    public bool isGameOver;
    public Text LifeText;
    public Text GameOverText;
    // Use this for initialization
    void Start () {
        PacLifes = 3;
        LifeText.text = "Lifes: " + PacLifes;
        isGameOver = false;
    }

    public void ReduceLife()
    {
        GameOverText.text = "PRESS R TO RESPAWN";
        SetLife(PacLifes--);
        isGameOver = true;
    }

    public void SetLife(int lifes)
    {
        PacLifes = lifes;
        LifeText.text = "Lifes: " + PacLifes;
    }
}
