using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour {

    [SerializeField]
     float speed = 0.4f;

    Vector2 dest = Vector2.zero;

    void Start ()
    {
        dest = transform.position;
    }

    void FixedUpdate()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }

        // Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir)
    {
        //pacman ile arasında duvar var mi
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'

        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>()); //hit collider pacman collideri mi ? 

        //pacman kon+yön den pacmane ..
        //we simply casted the Line from the point next to Pac-Man (pos + dir) to Pac-Man himself (pos).
    }

    public void GameOverPac()
    {
        //sbug
        this.enabled = false;
        FindObjectOfType<SoundControl>().PacmanDeath();
        GetComponent<Animator>().SetBool("gameover", true);
    }
}

