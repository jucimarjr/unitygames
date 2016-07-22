using UnityEngine;
using System.Collections;

public class BigDot : Dot {
    // Use this for initialization
    void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    public override void OnEated()
    {
        sceneScript.AddScore(50);
        sceneScript.SetGhostMode(Mode.Fright);
        Destroy(gameObject);
    }
}
