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
    public GameObject pac;

    // Use this for initialization
    void Start()
    {
        followscript = GetComponent<FollowTarget>();
        frightscript = GetComponent<Frightened>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (VerifyHouse() && mode == Mode.ExitHouse)
            mode = Mode.Scatter;
        
        if(mode == Mode.Eyes)
            VerifyOnHouse();
        
        
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
                followscript.CanEnterHouse = false;
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
                    return true;
            }
        
        return false;
    }

    public void Reset()
    {
        transform.position = followscript.StartPoint;
        mode = Mode.Waiting;
    }

    void VerifyOnHouse()
    {
        Vector3 target = followscript.Target;
        float dist = Vector2.Distance(target, transform.position);
        if(dist < 0.5f)
        {
            mode = Mode.ExitHouse;
            followscript.returning = false;
            followscript.velocity = 5;
            GetComponent<Animator>().SetTrigger("left");
        }
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
                Vector2 inkyTarget = (Vector2)blinky.transform.position + 2 * 
                                     (inkyOffset - (Vector2)blinky.transform.position);
                followscript.SetTarget(inkyTarget);
                break;
            case Ghost.Pinky:
                Vector2 pinkyTarget = pac.GetComponent<MazeMovement>().PositionWithOffset(4);
                followscript.SetTarget(pinkyTarget);
                break;
            case Ghost.Clyde:
                float clydeDistance = Vector2.Distance(pac.transform.position, transform.position);
                if (clydeDistance > 8)
                    followscript.SetTarget(pac.transform.position);
                else
                    followscript.SetScatter();
                break;
        }
    }

    public void ChangeMode(Mode newMode)
    {
        if (mode != newMode)
        {
            if(mode == Mode.Waiting && newMode == Mode.ExitHouse)
                mode = newMode;
            else if(mode == Mode.ExitHouse && newMode == Mode.Scatter)
                mode = newMode;
            else if(mode == Mode.Scatter)
            {
                if (newMode == Mode.Chase || newMode == Mode.Fright)
                    mode = newMode;
            }                
            else if(mode == Mode.Chase)
            {
                if (newMode == Mode.Scatter || newMode == Mode.Fright)
                    mode = newMode;
            }                
            else if(mode == Mode.Fright)
            {
                if (newMode == Mode.Chase || newMode == Mode.Scatter || newMode == Mode.Eyes)
                    mode = newMode;
            }                
            else if(mode == Mode.Eyes && newMode == Mode.Waiting)
                mode = newMode;
            if (newMode == Mode.Waiting)
                mode = newMode;
        }
    }   
}
