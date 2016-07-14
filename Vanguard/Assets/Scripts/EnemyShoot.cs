using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    public float time;
    public float timeVariation;
    bool CanShoot;
    public GameObject Bullet;
    public Vector2 direction;
    public float velocity;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(time + Random.Range(-timeVariation, timeVariation));
            GetComponent<AudioSource>().Play();
            GameObject NewBullet = (GameObject)Instantiate(Bullet, transform.position, Quaternion.identity);
            NewBullet.GetComponent<Rigidbody2D>().rotation = Vector2.Angle(Vector2.right, direction);
            NewBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * velocity;
        }
    }

    public void OnBecameVisible()
    {
        StartCoroutine(Shoot());
    }


}
