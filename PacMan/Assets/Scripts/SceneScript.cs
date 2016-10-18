using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneScript : MonoBehaviour {
    [Range(0,1)]
    public float timeScale;

    int InkyCount, PinkyCount, ClydeCount, GlobalCount;
    bool ActiveGlobalCount;
    float LastDotEated;
    Ghost ActiveCounter;    

    public Mode ActiveMode;
    public GameObject pacman;
    public GhostModes blinky, inky, pinky, clyde;

    float ScatterTime, ChaseTime, FrightTime;

    public ScoreController Score;
    public LifeController Life;
    public SoundController Sound;

	// Use this for initialization
	void Start () {
        Sound.PlayLooped("walking");
        ActiveCounter = Ghost.Pinky;
        ActiveGlobalCount = false;
        blinky.ChangeMode(Mode.ExitHouse);
        ActiveMode = Mode.Scatter;
        ScatterTime = Time.time + 7;
        ChaseTime = Time.time + 30;
        FrightTime = Time.time + 6;
    }
    
	// Update is called once per frame
	void Update () {
        Time.timeScale = timeScale;        
        if (Life.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (Life.PacLifes <= 0)
                    SceneManager.LoadScene("Main2");
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
            }else if (Input.GetKeyDown(KeyCode.D))
            {
                blinky.GetComponent<FollowTarget>().ChangeDrawLine();
                inky.GetComponent<FollowTarget>().ChangeDrawLine();
                pinky.GetComponent<FollowTarget>().ChangeDrawLine();
                clyde.GetComponent<FollowTarget>().ChangeDrawLine();
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
                Score.GhostMult = 100;
                SetGhostMode(Mode.Scatter);
                ScatterTime = Time.time + 7;
            }
            
            if (Score.DotsEated >= 240)
            {
                Win();
            }
            
        }
        
    }

    void Win()
    {
        Life.isGameOver = true;
        Life.PacLifes = 0;
        Life.GameOverText.text = "YOU WIN\nPRESS R TO RESTART";
        Sound.PlaySound("pacwin");
        Sound.StopLooped("walking");
        SetGhostMode(Mode.Waiting);
        pacman.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        pacman.GetComponent<PacMovement>().enabled = false;
    }

    public void GhostPacCounterAdd()
    {
        LastDotEated = Time.time;
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

        if(LastDotEated + 4 < Time.time)
        {
            LastDotEated = Time.time;
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
        Score.GhostMult = 100;
        blinky.Reset();
        inky.Reset();
        pinky.Reset();
        clyde.Reset();
        ActiveGlobalCount = true;
        Life.isGameOver = false;
        ActiveMode = Mode.Scatter;
        ScatterTime = Time.time + 7;
        ChaseTime = Time.time + 30;
        FrightTime = Time.time + 6;
        Life.GameOverText.text = "";
        pacman.GetComponent<PacDie>().Respawm();
        SetGhostMode(Mode.ExitHouse);
        Sound.PlaySound("paclive");
        Sound.PlayLooped("walking");
    }

    public void SetGhostMode(Mode mode)
    {
        if(mode == Mode.Fright)
            FrightTime = Time.time + 6;
        if(!(mode == Mode.Waiting || mode == Mode.ExitHouse))
            ActiveMode = mode;
        blinky.ChangeMode(mode);
        inky.ChangeMode(mode);
        pinky.ChangeMode(mode);
        clyde.ChangeMode(mode);
    }
}