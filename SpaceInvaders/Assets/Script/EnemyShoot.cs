using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyShoot : MonoBehaviour {
    public GameObject BulletPrefab;
    public float BulletVelocity;
    public float ShootTime;
    public List<GameObject> Enemies;
    public bool CanShoot;
    public Text GameOver;
	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("BulletEnemy"), LayerMask.NameToLayer("Enemy"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("BulletEnemy"), LayerMask.NameToLayer("BulletPlayer"));
        for (int i = 0; i < transform.childCount; i++)
        {
            Enemies.Add(transform.GetChild(i).gameObject);
        }
        StartCoroutine(Shoot());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Shoot()
    {
        while (CanShoot)
        {
            yield return new WaitForSeconds(ShootTime);
            for (var i = Enemies.Count - 1; i > -1; i--)
            {
                if (Enemies[i] == null)
                    Enemies.RemoveAt(i);
            }
            if (Enemies.Count <= 0)
            {
                CanShoot = false;
                FindObjectOfType<PlayerDie>().Win();
                yield break;
            }
            int Index = Random.Range(0, Enemies.Count - 1);
            GameObject enemy = Enemies[Index];
            while(enemy == null)
            {
                Index = Random.Range(0, Enemies.Count - 1);
                enemy = Enemies[Index];
            }
            GameObject NewBullet = Instantiate(BulletPrefab, enemy.transform.position, Quaternion.identity) as GameObject;
            NewBullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * BulletVelocity;
        }
    }
}
