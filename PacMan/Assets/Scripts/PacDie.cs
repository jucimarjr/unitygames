﻿using UnityEngine;
using System.Collections;

public class PacDie : MonoBehaviour {
    public bool Alive;
    Animator anim;
	// Use this for initialization
	void Start () {
        Alive = true;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Die()
    {
        anim.SetTrigger("die");
        GetComponent<PacMovement>().enabled = false;
        anim.speed = 1;
    }

    public void Respawm()
    { 
        anim.speed = 1;
        transform.position = GetComponent<PacMovement>().StartPoint;
        anim.SetTrigger("reset");
        GetComponent<PacMovement>().enabled = true;
        Alive = true;
    }
}
