using UnityEngine;
using System.Collections;

public class PacDie : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Die()
    {
        GetComponent<Animator>().SetTrigger("die");
        GetComponent<PacMovement>().enabled = false;
        GetComponent<Animator>().speed = 1;
    }
}
