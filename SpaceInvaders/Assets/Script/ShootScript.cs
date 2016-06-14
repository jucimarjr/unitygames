using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {
    public GameObject BulletPrefab;
    public bool CanShoot;
    public float BulletVelocity;
    public float ShootDelay;
	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("BulletPlayer"));
        StartCoroutine(Shoot());
	}

    IEnumerator Shoot()
    {
        while (CanShoot)
        {
            GameObject NewBullet = Instantiate(BulletPrefab, transform.position, transform.rotation) as GameObject;
            NewBullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * BulletVelocity;
            yield return new WaitForSeconds(ShootDelay);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
