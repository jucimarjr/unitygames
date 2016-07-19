using UnityEngine;
using System.Collections;

public enum Mode
{
    Chase,
    Scatter,
    Fright,
    Eyes,
    ExitHouse,
    Waiting
}

public enum Ghost
{
    Blinky,
    Inky,
    Pinky,
    Clyde
}

public class GhostModes : MonoBehaviour
{
    public Mode mode;
    public Ghost ghost;
    FollowTarget followscript;
    Frightened frightscript;
    GameObject pac;

    // Use this for initialization
    void Start()
    {
        pac = GameObject.Find("PacMan");
        followscript = GetComponent<FollowTarget>();
        frightscript = GetComponent<Frightened>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mode = Mode.Chase;
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mode = Mode.Scatter;
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mode = Mode.Fright;
        }else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            mode = Mode.ExitHouse;
        }

        
        if (VerifyHouse() && mode == Mode.ExitHouse)
        {
            mode = Mode.Scatter;
        }
        
        switch (mode)
        {
            case Mode.Chase:
                if (!followscript.enabled)
                    followscript.enabled = true;
                frightscript.enabled = false;
                SetTarget();
                break;
            case Mode.Scatter:
                if (!followscript.enabled)
                    followscript.enabled = true;
                frightscript.enabled = false;
                followscript.SetScatter();
                break;
            case Mode.Fright:
                followscript.enabled = false;
                frightscript.enabled = true;
                break;
            case Mode.Eyes:
                frightscript.enabled = false;
                if (!followscript.enabled)
                    followscript.enabled = true;
                followscript.ReturnHome();
                break;
            case Mode.ExitHouse:
                if (!followscript.enabled)
                    followscript.enabled = true;
                frightscript.enabled = false;
                followscript.SetTarget(new Vector2(0, 4.5f));
                break;
            case Mode.Waiting:
                followscript.enabled = false;
                frightscript.enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                break;
        }
    }

    bool VerifyHouse()
    {
        
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("HouseExit"))
                {
                    return true;
                }
            }
        
        return false;
    }

    void SetTarget()
    {
        switch (ghost)
        {
            case Ghost.Blinky:
                followscript.SetTarget(pac.transform.position);
                break;
            case Ghost.Inky:
                Vector2 inkyOffset = pac.GetComponent<MazeMovement>().PositionWithOffset(2);
                GameObject blinky = GameObject.Find("blinky");
                Vector2 inkyTarget = (Vector2)blinky.transform.position + 2 * (inkyOffset - (Vector2)blinky.transform.position);
                followscript.SetTarget(inkyTarget);
                break;
            case Ghost.Pinky:
                Vector2 pinkyTarget = pac.GetComponent<MazeMovement>().PositionWithOffset(4);
                followscript.SetTarget(pinkyTarget);
                break;
            case Ghost.Clyde:
                float clydeDistance = Vector2.Distance(pac.transform.position, transform.position);
                if (clydeDistance > 8)
                {
                    followscript.SetTarget(pac.transform.position);
                }
                else
                {
                    followscript.SetScatter();
                }
                break;
        }
    }

    public void ChangeMode(Mode newMode)
    {
        if (mode != newMode)
        {
            mode = newMode;
        }
    }
   
}
