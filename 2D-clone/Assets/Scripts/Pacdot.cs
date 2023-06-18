using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour {

    private int foodsConsumed = 0;

    public void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("pacmantag"))
        {
            FindObjectOfType<SoundControl>().PlayMunchSound();
            FindObjectOfType<ScoreControl>().updateScore();
            Destroy(gameObject);
            foodsConsumed++;
        }   //Debug.Log("SCORE: " + GameObject.Find("ScoreControl").GetComponent<ScoreControl>().score);
    }// high-score..
}
