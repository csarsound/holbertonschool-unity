using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject winCanvas;
    public Text time;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player.GetComponent<Timer>().StopAllCoroutines();
            Timer timer = other.GetComponent<Timer>();
            time.color = Color.green;
            time.fontSize = 60;
            winCanvas.SetActive(true);

            if (timer != null)
            {
                timer.Win();
            }
        }
    }
}
