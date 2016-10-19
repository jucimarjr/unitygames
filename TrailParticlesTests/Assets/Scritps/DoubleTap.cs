using UnityEngine;
using System.Collections;

public class DoubleTap : MonoBehaviour {
    public float TapTime;
    float firstTapTime;
    bool firstTap;

    public delegate void DoubleTapDel();
    public DoubleTapDel onDoubleTap;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (firstTap)
            {
                firstTapTime = Time.time;
                firstTap = false;
            }else
            {
                onDoubleTap();
            }
        }

        if ((Time.time > firstTapTime + TapTime) && !firstTap)
        {
            firstTap = true;
        }
    }
}
