using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour
{
    public int Lifes;
    public Vector3 SpawnPointCameraRelative;
    public GameObject Explosion;
    // Use this for initialization
    void Start()
    {
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GameObject NewExplosion = (GameObject)Instantiate(Explosion, transform.position, Quaternion.identity);
    }

    void Respawn()
    {
        transform.position = Camera.main.ViewportToWorldPoint(SpawnPointCameraRelative);
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void ReduceLife()
    {
        Lifes--;
        if (Lifes < 0)
            Lifes = 0;
    }

    public IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ReduceLife();
            Explode();
            yield return new WaitForSeconds(1);
            Respawn();
        }
    }
}