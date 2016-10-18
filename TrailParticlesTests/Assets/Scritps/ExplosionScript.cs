using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {
    ParticleSystem sistem;
	// Use this for initialization
	void Start () {
        sistem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!sistem.IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
