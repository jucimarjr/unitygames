using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmallDot : Dot {
    public Text txt;
    public Vector2 tilepos;
	// Use this for initialization
	void Start () {
        base.Start();
        txt.text = "Dots Eated: " + sceneScript.DotsEated;
    }
	
	// Update is called once per frame
	void Update () {
        tilepos = GetTilePosition();
        base.Update();
	}

    public override void OnEated()
    {
        sceneScript.DotsEated++;
        sceneScript.GhostPacCounterAdd();
        txt.text = "Dots Eated: " + sceneScript.DotsEated;
        sceneScript.AddScore(10);
        sceneScript.PlaySound("eatingdot", true);
        Destroy(gameObject);
    }
}
