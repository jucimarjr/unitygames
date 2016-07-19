using UnityEngine;
using System.Collections;

public class Dot : MonoBehaviour {
    protected GameObject pac;
    protected SceneScript sceneScript;
    // Use this for initialization
    protected void Start () {
        sceneScript = GameObject.FindObjectOfType<SceneScript>();
        pac = GameObject.Find("PacMan");
    }
	
	// Update is called once per frame
	protected void Update () {
        if (pac.GetComponent<MazeMovement>().TilePosition.x == GetTilePosition().x && pac.GetComponent<MazeMovement>().TilePosition.y == GetTilePosition().y)
        {
            OnEated();
        }
    }

    public virtual void OnEated()
    {
        Debug.Log("Eated");
    }

    protected Vector2 GetTilePosition()
    {
        return new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f);
    }
}
