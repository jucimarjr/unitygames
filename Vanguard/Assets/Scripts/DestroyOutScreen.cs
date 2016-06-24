using UnityEngine;
using System.Collections;

public class DestroyOutScreen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
