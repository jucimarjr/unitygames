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
            if(mode.mode == Mode.Fright)
            {
                mode.ChangeMode(Mode.Eyes);

                scenescript.GhostMult *= 2;
                scenescript.AddScore(scenescript.GhostMult); 
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

    void KillPacMan()
    {
        if (pac.GetComponent<PacDie>().Alive)
        {
            pac.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            pac.GetComponent<PacDie>().Die();

            scenescript.ReduceLife();
        }
    }
}
