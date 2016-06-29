using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinLevel : MonoBehaviour
{
    public Text GameOverText;
    public bool win = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Menu");
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ControlMovement>().enabled = false;
            collision.gameObject.GetComponent<CameraRelatedLimits>().enabled = false;
            win = true;
            GameOverText.text = "You Win\nScore: " + GameObject.FindObjectOfType<ScoreControl>().Score;
        }
    }
}
