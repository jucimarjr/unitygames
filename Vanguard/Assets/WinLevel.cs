using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinLevel : MonoBehaviour
{
    public Text GameOverText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameOverText.text = "You Win\nScore: " + GameObject.FindObjectOfType<ScoreControl>().Score;
            Destroy(collision.gameObject);
        }
    }
}
