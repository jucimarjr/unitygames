using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    public float DistanceMoving;
    public float DistanceDownMoving;
    public float MoveDelay;
    public float MoveTime;
    public float MoveTimeReduction;
    public int Direction;
    public bool Moving;
    public int MoveCount;
    int LateralMovementCount;
    int DownMovementCount;
	// Use this for initialization
	void Start () {
        StartCoroutine(Move());
        LateralMovementCount = 0;
        DownMovementCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Move()
    {
        while (Moving)
        {
            yield return new WaitForSeconds(MoveTime + MoveDelay);
            MoveDelay = 0;
            LateralMovementCount++;
            if(LateralMovementCount > MoveCount)
            {
                LateralMovementCount = -MoveCount;
                Direction = -Direction;
                DownMovementCount++;
                MoveTime = MoveTime - MoveTimeReduction;
                transform.Translate(DistanceDownMoving * Vector3.down);
            }else
                transform.Translate(DistanceMoving * Vector3.right * Direction);
        }
    }
}
