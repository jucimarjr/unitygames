using UnityEngine;
using System.Collections;

public class SceneScript : MonoBehaviour {
    public int DotsEated;
    public int Score;
    public int PacLifes;

    public Mode mode;
    public GameObject pacman;
    public GameObject blinky;
    public GameObject inky;
    public GameObject pinky;
    public GameObject clyde;
	// Use this for initialization
	void Start () {
        DotsEated = 0;
        Score = 0;
        PacLifes = 3;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void ChaseMode()
    {
        blinky.GetComponent<FollowTarget>().SetTarget(pacman.transform.position);

        Vector2 pinkyTarget = pacman.GetComponent<MazeMovement>().PositionWithOffset(4);
        pinky.GetComponent<FollowTarget>().SetTarget(pinkyTarget);

        Vector2 inkyOffset = pacman.GetComponent<MazeMovement>().PositionWithOffset(2);
        Vector2 inkyTarget = (Vector2)blinky.transform.position + 2 * (inkyOffset - (Vector2)blinky.transform.position);
        inky.GetComponent<FollowTarget>().SetTarget(inkyTarget);

        float clydeDistance = Vector2.Distance(pacman.transform.position, clyde.transform.position);
        if (clydeDistance > 8)
        {
            clyde.GetComponent<FollowTarget>().SetTarget(pacman.transform.position);
        }
        else
        {
            clyde.GetComponent<FollowTarget>().SetScatter();
        }
    }

    public void ScatterMode()
    {
        blinky.GetComponent<FollowTarget>().SetScatter();
        inky.GetComponent<FollowTarget>().SetScatter();
        pinky.GetComponent<FollowTarget>().SetScatter();
        clyde.GetComponent<FollowTarget>().SetScatter();
    }
}
