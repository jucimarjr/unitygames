using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneScript : MonoBehaviour {
    public int DotsEated;
    public int Score;
    public int PacLifes;
    [Range(0,1)]
    public float timeScale;

    public int InkyCount, PinkyCount, ClydeCount, GlobalCount;
    bool ActiveGlobalCount;
    float lastDotTile;

    public Ghost ActiveCounter;

    public int GhostMult;

    public Text ScoreText;
    public Text LifeText;
    public Text GameOverText;

    public Mode ActiveMode;
    public GameObject pacman;
    public GhostModes blinky;
    public GhostModes inky;
    public GhostModes pinky;
    public GhostModes clyde;

    public float ScatterTime;
    public float ChaseTime;
    public float FrightTime;

    public bool isGameOver;
	// Use this for initialization
	void Start () {
        ActiveCounter = Ghost.Pinky;
        ActiveGlobalCount = false;
        isGameOver = false;
        DotsEated = 0;
        Score = 0;
        PacLifes = 3;
        GhostMult = 100;
        AddScore(0);
        LifeText.text = "Lifes: " + PacLifes;
        blinky.ChangeMode(Mode.ExitHouse);

        ActiveMode = Mode.Scatter;
        ScatterTime = Time.time + 7;
        ChaseTime = Time.time + 30;
        FrightTime = Time.time + 6;

    }

    public void AddScore(int add)
    {
        Score += add;
        ScoreText.text = "Score: " + Score;
    }

    public void ReduceLife()
    {
        GameOverText.text = "PRESS R TO RESPAWN";
        SetGhostMode(Mode.Waiting);
        PacLifes--;
        isGameOver = true;
    }
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = timeScale;

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (PacLifes <= 0)
                    SceneManager.LoadScene("testes");
                else
                    RestartLevel();
            }
        }
        else
        {


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetGhostMode(Mode.Chase);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetGhostMode(Mode.Scatter);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetGhostMode(Mode.Fright);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SetGhostMode(Mode.ExitHouse);
            }

            VerifyGhostExit();

            if (ActiveMode == Mode.Scatter && Time.time > ScatterTime)
            {
                SetGhostMode(Mode.Chase);
                ChaseTime = Time.time + 30;
            }
            else if (ActiveMode == Mode.Chase && Time.time > ChaseTime)
            {
                SetGhostMode(Mode.Scatter);
                ScatterTime = Time.time + 7;
            }
            else if (ActiveMode == Mode.Fright && Time.time > FrightTime)
            {
                SetGhostMode(Mode.Scatter);
                ScatterTime = Time.time + 7;
            }

            if (DotsEated >= 240)
            {
                Win();
            }
        }
        
    }

    void Win()
    {
        isGameOver = true;
        PacLifes = 0;
        GameOverText.text = "YOU WIN, PRESS R TO RESTART";
        SetGhostMode(Mode.Waiting);
        pacman.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        pacman.GetComponent<PacMovement>().enabled = false;
    }

    public void GhostPacCounterAdd()
    {
        lastDotTile = Time.time;
        if (!ActiveGlobalCount)
        {
            switch (ActiveCounter)
            {
                case Ghost.Pinky:
                    PinkyCount++;
                    break;
                case Ghost.Inky:
                    InkyCount++;
                    break;
                case Ghost.Clyde:
                    ClydeCount++;
                    break;
            }
        }else
        {
            GlobalCount++;
        }
    }

    void VerifyGhostExit()
    {        
        if (ActiveGlobalCount)
        {
            if(GlobalCount >= 7)
            {
                pinky.ChangeMode(Mode.ExitHouse);
            }else if(GlobalCount >= 17)
            {
                inky.ChangeMode(Mode.ExitHouse);
            }else if(GlobalCount == 32 && clyde.mode == Mode.Waiting)
            {
                ActiveGlobalCount = false;
                ActiveCounter = Ghost.Clyde;
            }
        }
        else if (ActiveCounter == Ghost.Pinky)
        {
            if (PinkyCount >= 0 && pinky.mode == Mode.Waiting)
            {
                pinky.ChangeMode(Mode.ExitHouse);
                ActiveCounter = Ghost.Inky;
            }
        }else if(ActiveCounter == Ghost.Inky)
        {
            if(InkyCount >= 30 && inky.mode == Mode.Waiting)
            {
                inky.ChangeMode(Mode.ExitHouse);
                ActiveCounter = Ghost.Clyde;
            }
        }else if(ActiveCounter == Ghost.Clyde)
        {
            if(ClydeCount >= 60 && clyde.mode == Mode.Waiting)
            {
                clyde.ChangeMode(Mode.ExitHouse);
                ActiveCounter = Ghost.Blinky;
            }
        }

        if(lastDotTile + 4 < Time.time)
        {
            lastDotTile = Time.time;
            switch (ActiveCounter)
            {
                case Ghost.Pinky:
                    pinky.ChangeMode(Mode.ExitHouse);
                    ActiveCounter = Ghost.Inky;
                        break;
                case Ghost.Inky:
                    inky.ChangeMode(Mode.ExitHouse);
                    ActiveCounter = Ghost.Clyde;
                    break;
                case Ghost.Clyde:
                    clyde.ChangeMode(Mode.ExitHouse);
                    ActiveCounter = Ghost.Pinky;
                    break;
            }
        }
    }

    void RestartLevel()
    {
        blinky.Reset();
        inky.Reset();
        pinky.Reset();
        clyde.Reset();
        ActiveGlobalCount = true;
        isGameOver = false;
        LifeText.text = "Lifes: " + PacLifes;
        GameOverText.text = "";
        pacman.GetComponent<PacDie>().Respawm();
        SetGhostMode(Mode.ExitHouse);
    }

    public void SetGhostMode(Mode mode)
    {
        if(mode == Mode.Fright)
        {
            FrightTime = Time.time + 6;
        }
        if(mode != Mode.Waiting && mode != Mode.ExitHouse)
            ActiveMode = mode;
        blinky.ChangeMode(mode);
        inky.ChangeMode(mode);
        pinky.ChangeMode(mode);
        clyde.ChangeMode(mode);
    }
}
