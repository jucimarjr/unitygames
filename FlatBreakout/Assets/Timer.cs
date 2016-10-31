using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Timer : MonoBehaviour {
    public float MaxTime;
    float ActualTime;
    public Text TimerText;
    public Score ScoreScript;
	// Use this for initialization
	void Start () {
        ActualTime = MaxTime;
        TimerText.text = "" + ActualTime;
        StartCoroutine(ActualizeTime());
    }

    IEnumerator ActualizeTime()
    {
        while (ScoreScript.running)
        {
            yield return new WaitForSeconds(1);
            ActualTime -= 1;
            TimerText.text = "" + ActualTime;
            if(ActualTime <= 0)
            {
                ScoreScript.GameOver();
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
