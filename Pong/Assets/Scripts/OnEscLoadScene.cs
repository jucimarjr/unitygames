using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OnEscLoadScene : MonoBehaviour {
    public string scene;
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Cancel"))
        {
            GetComponent<LoadScene>().Load(scene);
        }
	}
}
