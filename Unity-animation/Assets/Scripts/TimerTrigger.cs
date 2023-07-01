using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public GameObject player;

    // Start enable Timer
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
            player.GetComponent<Timer>().enabled = true;
            GetComponent<TimerTrigger>().enabled = false;
        }
    }
}
