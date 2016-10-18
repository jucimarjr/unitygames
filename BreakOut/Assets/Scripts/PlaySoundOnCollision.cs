using UnityEngine;
using System.Collections;

public class PlaySoundOnCollision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
