using UnityEngine;
using System.Collections;

public class NumberOfPlayers : MonoBehaviour {
    public static int players = 1;
    public GameObject buttons;
    public GameObject menu;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnePlayer()
    {
        players = 1;
    }

    public void TwoPlayers()
    {
        players = 2;
    }

    public void Play()
    {
        buttons.SetActive(true);
        menu.SetActive(false);
    }
}
