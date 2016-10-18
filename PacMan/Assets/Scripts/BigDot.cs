using UnityEngine;
using System.Collections;

public class BigDot : Dot {
    void Update () {
        base.Update();
	}

    public override void OnEated()
    {
        //Tornar os fantasmas azuis
        FindObjectOfType<SceneScript>().SetGhostMode(Mode.Fright);
        ScoreScript.AddScore(50);
        base.OnEated();
    }
}
