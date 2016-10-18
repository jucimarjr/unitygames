using UnityEngine;
using System.Collections;

public class Dot : MonoBehaviour {
    public GameObject pac;
    public ScoreController ScoreScript;
    public SoundController Sounds;
	protected void Update () {
        if (pac.GetComponent<MazeMovement>().TilePosition.x == GetTilePosition().x && 
            pac.GetComponent<MazeMovement>().TilePosition.y == GetTilePosition().y)
        {
            OnEated();
        }
    }

    public virtual void OnEated()
    {
        Sounds.PlaySound("eatingdot");
        Destroy(gameObject);
    }

    protected Vector2 GetTilePosition()
    {
        return new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f);
    }
}
