using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMove : MonoBehaviour
{

    public Transform[] waypoints;
    int cur = 0; //blinky current loc

    public float speed = 0.3f;

    void Start()
    {
    }

    void FixedUpdate()
    {
        // Waypoint not reached yet? then move closer
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else cur = (cur + 1) % waypoints.Length;
        //list uzunlugu asılırsa 0la
        //if (cur == waypoints.Length) cur = 0 gibi de olur.

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "pacman")
        {
            //Destroy(col.gameObject);
            //game over 
            FindObjectOfType<PacmanMove>().GameOverPac();
            StartCoroutine(ResetLevel());
        }
    }
    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Level1");
    }
}