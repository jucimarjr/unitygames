using UnityEngine;
using System.Collections;

public class BackGroundSound : MonoBehaviour {
    public float initDelay;
    public float reduxDelay;


	// Use this for initialization
	void Start () {
        StartCoroutine(PlaySound());
	}

    IEnumerator PlaySound()
    {
        while (true)
        {
            yield return new WaitForSeconds(initDelay);
            initDelay -= reduxDelay;
            GetComponent<AudioSource>().Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
