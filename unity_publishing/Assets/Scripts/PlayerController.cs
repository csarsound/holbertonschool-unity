using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Load scene
using UnityEngine.UI; // Use UI for scoreText

public class PlayerController : MonoBehaviour
{
    // Variable that can be edited in the Inspector
    public float speed = 300f;
    public int health = 5;
    public Text scoreText; 
    public Text HealthText;
    public GameObject winLose;
    public Image winLoseImg;
    public Text winLoseText;

    // This is a reference to the Rigibody
    public Rigidbody rb;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(1);

        if (health == 0)
        {
            winLose.SetActive(true);
            winLoseImg.color = new Color(1, 0, 0, 1);
            winLoseText.color = new Color(1, 1, 1, 1);
            winLoseText.text = "Game Over!";
            StartCoroutine(LoadScene(3));
        }
    }

    // it is called every fixed frame-rate frame.
    void FixedUpdate()
    {
        // Add speed force
        if ( Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }

        if ( Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }

        if ( Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }

    // Manipulate Objects with the Tags
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            //  Show Score on Canvas
            SetScoreText();
            Debug.Log($"Score: {score}");
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Trap")
        {
            health -= 1;
            // Show Score on Canvas
            SetHealthText();
            Debug.Log($"Health: {health}");
        }

        if (other.tag == "Goal")
        {
            winLose.SetActive(true);
            winLoseText.text = "YouWin!";
            winLoseText.color = new Color(0, 0, 0, 1);
            winLoseImg.color = new Color(0,1,0);
            StartCoroutine(LoadScene(3));
        }

        void SetScoreText()
        {
            scoreText.text = $"Score: {score.ToString()}";
        }

        void SetHealthText()
        {
            HealthText.text = $"Health: {health.ToString()}";
        }
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
}
