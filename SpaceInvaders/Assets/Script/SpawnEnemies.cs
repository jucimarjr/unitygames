using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {
    public List<GameObject> EnemiesPrefabs = new List<GameObject>();
    public int EnemiesPerLine;
    public int EnemiesColumn;
    public float EnemiesDistance;
    public float EnemiesColumnDistance;
    public float EnemyDelay;
	// Use this for initialization
	void Start () {
        float enemyDelay = 0;
        EnemiesDistance = (1 / (float)EnemiesPerLine) * 2.8f * 2f;

	    for(int i = 0; i < EnemiesColumn; i++)
        {
            int e = Random.Range(0, EnemiesPrefabs.Count - 1);
            for(int j = 0; j < EnemiesPerLine; j++)
            {
                Vector3 NewPosition = new Vector3(transform.position.x - ((j + 1) * EnemiesDistance) + EnemiesDistance/2, transform.position.y + (i * EnemiesColumnDistance) + (7 - EnemiesColumn) * EnemiesColumnDistance, 0);
                GameObject NewEnemy = Instantiate(EnemiesPrefabs[e], NewPosition, Quaternion.identity) as GameObject;
                NewEnemy.transform.parent = transform;
                NewEnemy.GetComponent<EnemyMovement>().MoveDelay = enemyDelay;
                enemyDelay += EnemyDelay;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
