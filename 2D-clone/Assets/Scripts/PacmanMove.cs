using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour {

    [SerializeField]
    float speed = 0.1f;
    float speedTeclado = 0.4f;

    Vector2 dest = Vector2.zero;
    Vector2 fin = Vector2.zero;
    public Joystick joystick;

    private bool isMovingWithJoystick = false;

    void Start ()
    {
        dest = transform.position;
        fin = transform.position;
    }

    void FixedUpdate()
    {
        Vector2 joystickDirection = new Vector2(joystick.Horizontal, joystick.Vertical);
        Vector2 joystickMovement = joystickDirection * speed;
        Vector2 t = Vector2.MoveTowards(transform.position, fin, speedTeclado);
        GetComponent<Rigidbody2D>().MovePosition(t);

        // Check if joystick input is significant
        if (joystickDirection.magnitude > 0.1f)
        {
            // Move based on joystick input
            Vector2 p = (Vector2)transform.position + joystickMovement;
            GetComponent<Rigidbody2D>().MovePosition(p);

            // Animation Parameters
            Vector2 dir = joystickDirection.normalized;
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);

            // Reset destination
            dest = transform.position;

            isMovingWithJoystick = true;
        }
        else
        {
            isMovingWithJoystick = false;
        }

        // Check for Input if not moving with joystick
        if ((Vector2)transform.position == fin && !isMovingWithJoystick)
        {

            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                fin = (Vector2)transform.position + Vector2.up;
            else if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                fin = (Vector2)transform.position + Vector2.right;
            else if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                fin = (Vector2)transform.position - Vector2.up;
            else if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                fin = (Vector2)transform.position - Vector2.right;
            
        Vector2 dire = fin - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dire.x);
        GetComponent<Animator>().SetFloat("DirY", dire.y);

            // Reset destination
            fin = transform.position;
        }
    }

    bool valid(Vector2 dire)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dire, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    public void GameOverPac()
    {
        this.enabled = false;
        FindObjectOfType<SoundControl>().PacmanDeath();
        GetComponent<Animator>().SetBool("gameover", true);
    }
}
