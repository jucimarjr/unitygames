using UnityEngine;
using System.Collections;

public class CollidePacMan : MonoBehaviour {
    public GameObject pac;
    GhostModes mode;
    public ScoreController Score;
    public LifeController Life;
    Transform pactransform;
	// Use this for initialization
	void Start () {
        mode = GetComponent<GhostModes>();
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
                Score.GhostMult *= 2;
                Score.AddScore(Score.GhostMult); 
            }
            else if(mode.mode == Mode.Chase || mode.mode == Mode.Scatter)
            {
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
            Life.ReduceLife();
        }
    }
}
