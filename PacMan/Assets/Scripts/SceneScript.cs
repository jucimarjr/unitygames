using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneScript : MonoBehaviour {
    public int DotsEated;
    public int Score;
    public int PacLifes;
    [Range(0,1)]
    public float timeScale;

    public Mode mode;
    public GameObject pacman;
    public GameObject blinky;
    public GameObject inky;
    public GameObject pinky;
    public GameObject clyde;

    public bool isGameOver;
	// Use this for initialization
	void Start () {
        isGameOver = false;
        DotsEated = 0;
        Score = 0;
        PacLifes = 3;
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = timeScale;

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void ChaseMode()
    {
        blinky.GetComponent<GhostModes>().ChangeMode(Mode.Chase);
        inky.GetComponent<GhostModes>().ChangeMode(Mode.Chase);
        pinky.GetComponent<GhostModes>().ChangeMode(Mode.Chase);
        clyde.GetComponent<GhostModes>().ChangeMode(Mode.Chase);
    }

    public void ScatterMode()
    {
        blinky.GetComponent<GhostModes>().ChangeMode(Mode.Scatter);
        inky.GetComponent<GhostModes>().ChangeMode(Mode.Scatter);
        pinky.GetComponent<GhostModes>().ChangeMode(Mode.Scatter);
        clyde.GetComponent<GhostModes>().ChangeMode(Mode.Scatter);
    }

    public void StopGhosts()
    {
        blinky.GetComponent<GhostModes>().ChangeMode(Mode.Waiting);
        inky.GetComponent<GhostModes>().ChangeMode(Mode.Waiting);
        pinky.GetComponent<GhostModes>().ChangeMode(Mode.Waiting);
        clyde.GetComponent<GhostModes>().ChangeMode(Mode.Waiting);
    }

    public void FrightMode()
    {
        blinky.GetComponent<GhostModes>().ChangeMode(Mode.Fright);
        inky.GetComponent<GhostModes>().ChangeMode(Mode.Fright);
        pinky.GetComponent<GhostModes>().ChangeMode(Mode.Fright);
        clyde.GetComponent<GhostModes>().ChangeMode(Mode.Fright);
    }
}
