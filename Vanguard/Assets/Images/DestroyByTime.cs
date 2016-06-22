using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
    public float time;
	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyNow());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator DestroyNow()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
