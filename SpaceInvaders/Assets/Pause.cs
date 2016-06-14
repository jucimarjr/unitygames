using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    public bool paused;
    public GameObject PauseMenu;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            PauseMenu.SetActive(true);
        }else
        {
            Time.timeScale = 1;
            paused = false;
            PauseMenu.SetActive(false);
        }
    }
}
