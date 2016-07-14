using UnityEngine;
using System.Collections;

public enum Mode
{
    Chase,
    Scatter,
    Fright,
    Eyes,
    ExitHouse
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



    GameObject pac;

    // Use this for initialization
    void Start()
    {
        pac = GameObject.Find("PacMan");
        followscript = GetComponent<FollowTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (VerifyHouse())
        {
            mode = Mode.ExitHouse;
        }else
        {
            mode = Mode.Scatter;
        }
        */
        switch (mode)
        {
            case Mode.Chase:
                SetTarget();
                break;
            case Mode.Scatter:
                followscript.SetScatter();
                break;
            case Mode.Fright:

                break;
            case Mode.Eyes:

                break;
            case Mode.ExitHouse:
                followscript.SetTarget(new Vector2(0, 4.5f));
                break;
        }
    }

    bool VerifyHouse()
    {
        Vector2[] directions = { Vector2.left, Vector2.up, Vector2.right, Vector2.down };
        foreach(Vector2 d in directions)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("GhostHouse"))
                {
                    return true;
                }
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Exit House");
        if (collision.gameObject.CompareTag("GhostHouse"))
        {
            mode = Mode.ExitHouse;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GhostHouse"))
        {
            mode = Mode.Scatter;
        }
    }
}
