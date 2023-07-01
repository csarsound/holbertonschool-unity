using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    // Reference to the Main Camera GameObject
    public GameObject mainCamera;

    //Reference to the Player GameObject
    public GameObject player;

    // Reference to the TimerCanvas
    public GameObject timerCanvas;

    private Animator animator;
    private bool animationFinished;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animationFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!animationFinished && !animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            // Level01 animation finished playing
            animationFinished = true;

            // Enable Main Camera
            mainCamera.SetActive(true);

            // Enable PlayerController script
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.enabled = true;

            // Enable TimerCanvas
            timerCanvas.SetActive(true);

            // Disable CutsceneController
            gameObject.SetActive(false);
        }
    }
}
