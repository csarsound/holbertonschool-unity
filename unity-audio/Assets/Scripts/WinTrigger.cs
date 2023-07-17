using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject winCanvas;
    public GameObject audio; // Ambient Sound Stop
    public Text time;
    private AudioSource victoryPiano;
    private bool IsSound;   

    void Start()
    {
        victoryPiano = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player.GetComponent<Timer>().StopAllCoroutines();
            Timer timer = other.GetComponent<Timer>();
            time.color = Color.green;
            time.fontSize = 60;
            winCanvas.SetActive(true);
            audio.SetActive(false);

            if (!IsSound)
            {
                victoryPiano.Play();
                IsSound = true;
            }

            if (timer != null)
            {
                timer.Win();
            }
        }
    }
}
