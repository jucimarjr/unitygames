using UnityEngine;
using System.Collections;

public class CameraRelatedLimits : MonoBehaviour {
    public float RightLimitPercentage;
    public float LefttLimitPercentage;
    public float UpLimitPercentage;
    public float DownLimitPercentage;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 PercentagePosition = Camera.main.WorldToViewportPoint(transform.position);
        
        if(PercentagePosition.x < LefttLimitPercentage)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(LefttLimitPercentage, PercentagePosition.y, PercentagePosition.z));
        }else if(PercentagePosition.x > RightLimitPercentage)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(RightLimitPercentage, PercentagePosition.y, PercentagePosition.z));
        }
        if(PercentagePosition.y < DownLimitPercentage)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(PercentagePosition.x, DownLimitPercentage, PercentagePosition.z));
        }
        else if(PercentagePosition.y > UpLimitPercentage)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(PercentagePosition.x, UpLimitPercentage, PercentagePosition.z));
        }
	}
}
