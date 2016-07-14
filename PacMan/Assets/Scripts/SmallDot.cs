using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmallDot : MazeMovement {
    GameObject pac;
    SceneScript sceneScript;
    Text txt;
	// Use this for initialization
	void Start () {
        base.Start();
        sceneScript = GameObject.FindObjectOfType<SceneScript>();
        pac = GameObject.Find("PacMan");
        txt = GameObject.Find("DotsEated").GetComponent<Text>();
        txt.text = "Dots Eated: " + sceneScript.DotsEated;
    }
	
	// Update is called once per frame
	void Update () {
        base.Update();
	    if(pac.GetComponent<MazeMovement>().TilePosition.x == TilePosition.x && pac.GetComponent<MazeMovement>().TilePosition.y == TilePosition.y)
        {
            sceneScript.DotsEated++;
            txt.text = "Dots Eated: " + sceneScript.DotsEated;
            Destroy(gameObject);
        }
	}
}
