using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmallDot : Dot {
    public Text txt;
	// Use this for initialization
	void Start () {
        txt.text = "Dots Eated: " + ScoreScript.DotsEated;
    }
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    public override void OnEated()
    {
        ScoreScript.DotsEated++;
        txt.text = "Dots Eated: " + ScoreScript.DotsEated;
        ScoreScript.AddScore(10);
        base.OnEated();
    }
}
