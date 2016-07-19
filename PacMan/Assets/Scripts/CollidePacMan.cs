using UnityEngine;
using System.Collections;

public class CollidePacMan : MonoBehaviour {
    GameObject pac;
    GhostModes mode;
    SceneScript scenescript;
    Transform pactransform;
	// Use this for initialization
	void Start () {
        pac = GameObject.Find("PacMan");
        mode = GetComponent<GhostModes>();
        scenescript = GameObject.FindObjectOfType<SceneScript>();
        pactransform = pac.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (TilePosition.ToTilePoint(transform.position).x == TilePosition.ToTilePoint(pactransform.position).x &&
            TilePosition.ToTilePoint(transform.position).y == TilePosition.ToTilePoint(pactransform.position).y)
        {
            Debug.Log(mode.mode);
            if(mode.mode == Mode.Fright)
            {
                mode.mode = Mode.Eyes;

                Debug.Log("Return Home");
            }
            else if(mode.mode == Mode.Eyes || mode.mode == Mode.Waiting)
            {
                //Nada acontece
            }else
            {
                //Fantasma mata pacman
                KillPacMan();
            }
        }
    }

    void EatGhost()
    {
        mode.mode = Mode.Eyes;
        
    }

    void KillPacMan()
    {
        Debug.Log("Kill");

        pac.GetComponent<PacDie>().Die();

        scenescript.StopGhosts();

        scenescript.isGameOver = true;
    }
}
