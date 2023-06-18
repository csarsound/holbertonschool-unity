using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {

    public AudioClip munch1;
    public AudioClip munch2;
    public AudioClip pacmanDeath;

    private AudioSource audioSource;

    private bool playedMunch1 = false;

    void Start () {

        audioSource = GetComponent<AudioSource>();
	}

    public void PlayMunchSound()
    {
       //audioSource.clip = munch;
       // audioSource.Play();,
       if (playedMunch1)
        {
            // Play munch 1 , set playedMuch1 to false;
            audioSource.PlayOneShot(munch2);
            playedMunch1 = false;
        }
        else
        {
            //Play munch 2, set playedMuch1 to true;
            audioSource.PlayOneShot(munch1);
            playedMunch1 = true;
        }
    }

    public void PacmanDeath()
    {
        audioSource.clip = pacmanDeath;
        audioSource.Play();
    }
}
