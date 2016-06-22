using UnityEngine;
using System.Collections;

public class CameraLimits : MonoBehaviour {
    public float RightLimit;
    public float LeftLimit;
    public float UpLimit;
    public float DownLimit;
    // Use this for initialization
    void Start () {

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

    public void SetLimits(float RightLimit, float LeftLimit, float UpLimit, float DownLimit)
    {
        this.RightLimit = RightLimit;
        this.LeftLimit = LeftLimit;
        this.UpLimit = UpLimit;
        this.DownLimit = DownLimit;
    }
}
