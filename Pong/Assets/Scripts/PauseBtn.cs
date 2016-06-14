using UnityEngine;
using System.Collections;

public class PauseBtn : MonoBehaviour {
    bool paused;
    public GameObject PauseMenu;
	// Use this for initialization
	void Start () {
        paused = false;
        Time.timeScale = 1;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
    }
}
