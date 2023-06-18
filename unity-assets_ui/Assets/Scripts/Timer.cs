using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text finalTime;
    private float time;
    private float minutes;
    private float seconds;
    private float milliseconds;

    private bool isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InGameTimer());
    }

     IEnumerator InGameTimer()
     {
        while (!isFinished)
        {
            // Time flow
            time += Time.deltaTime;
            minutes = (int)(time / 60 % 60);
            seconds = (int)(time % 60);
            milliseconds = (int)((time - (int)time) * 100);

            timerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, milliseconds);

            yield return null;
        }
     }

     public void Win()
     {
        if (!isFinished)
        {
            finalTime.text = timerText.text;
            isFinished = true;
        }
     }
}
