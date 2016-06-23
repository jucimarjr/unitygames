using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraLimits : MonoBehaviour {
    public List<Transform> ChangePoints;

    public float RightLimit;
    public float LeftLimit;
    public float UpLimit;
    public float DownLimit;

    // Use this for initialization
    void Start () {
        SetLimits();
    }
	
	// Update is called once per frame
	void Update () {
	    if(RightLimit < transform.position.x)
        {
            transform.position = new Vector3(RightLimit, transform.position.y, transform.position.z);
        }else if(LeftLimit > transform.position.x)
        {
            transform.position = new Vector3(LeftLimit, transform.position.y, transform.position.z);
        }
        if (UpLimit < transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, UpLimit, transform.position.z);
        }else if(DownLimit > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, DownLimit, transform.position.z);
        }
	}

    public void ChangeLimits()
    {
        ChangePoints.RemoveAt(0);
        SetLimits();
    }

    public void SetLimits()
    {
        if (ChangePoints[0].position.x > transform.position.x)
        {
            RightLimit = ChangePoints[0].position.x;
        }
        else
        {
            LeftLimit = ChangePoints[0].position.x;
        }
        if (ChangePoints[0].position.y > transform.position.y)
        {
            UpLimit = ChangePoints[0].position.y;
        }
        else
        {
            DownLimit = ChangePoints[0].position.y;
        }
    }
}
