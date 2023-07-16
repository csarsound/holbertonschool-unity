using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public PlayerController playerController;
    public GameObject timerCanvas;
    public GameObject cutsceneController;

    private bool introPlayed = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (!introPlayed && transform.position == new Vector3(0f, 2.5f, -6.25f))
        {
            introPlayed = true;
            EnableGameplay();
        }
    }

    private void EnableGameplay()
    {
        mainCamera.SetActive(true);
        playerController.enabled = true;
        timerCanvas.SetActive(true);
        cutsceneController.SetActive(false);
    }
}
