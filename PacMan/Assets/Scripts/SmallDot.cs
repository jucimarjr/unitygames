using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmallDot : Dot {
    Text txt;
    public Vector2 tilepos;
	// Use this for initialization
	void Start () {
        base.Start();
        txt = GameObject.Find("DotsEated").GetComponent<Text>();
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
        txt.text = "Dots Eated: " + sceneScript.DotsEated;
        Destroy(gameObject);
    }
}
