using UnityEngine;
using System.Collections;

public class ChangeDirection : MonoBehaviour {
    public Vector2 Direction;
    public Vector3 NewSpawnPoint;
    public float Angle;
    public float RightLimit;
    public float LeftLimit;
    public float UpLimit;
    public float DownLimit;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<AutoMovement>().ChangeDirection(Direction);
            coll.gameObject.GetComponent<AutoMovement>().ChangeAngle(Angle);
            coll.gameObject.GetComponent<Die>().SpawnPointCameraRelative = NewSpawnPoint;
            Camera.main.GetComponent<AutoMovement>().ChangeDirection(Direction);
            Camera.main.GetComponent<CameraLimits>().SetLimits(RightLimit, LeftLimit, UpLimit, DownLimit);
        }
    }
}
