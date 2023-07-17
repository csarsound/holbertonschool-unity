using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public AudioMixerSnapshot pausedSnapshot;
    public AudioMixerSnapshot unpausedSnapshot;
    private bool isPaused = false;
    private float previousTimeScale;

    void Start()
    {
        // Desactivar el canvas de menú de pausa al inicio
        pauseMenuCanvas.SetActive(false);
        // Establecer el AudioMixerSnapshot inicial
        unpausedSnapshot.TransitionTo(0f);
    }

    void Update()
    {
        // Verificar si se presiona la tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Desactivar el canvas de menú de pausa y reanudar el tiempo
        isPaused = false;
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = previousTimeScale;
        unpausedSnapshot.TransitionTo(0f);
    }

    public void Pause()
    {
        // Cambiar el estado de pausa, activar el canvas de menú de pausa y pausar el tiempo
        isPaused = true;
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        pauseMenuCanvas.SetActive(true);
        pausedSnapshot.TransitionTo(0f);
    }

    public void Restart()
    {
        // Reiniciar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Asegurarse de que el tiempo se reanude después del reinicio
        isPaused = false; // Desactivar el estado de pausa después del reinicio
        unpausedSnapshot.TransitionTo(0f);
    }

    public void MainMenu()
    {
        // Cambiar a la escena MainMenu
        SceneManager.LoadScene("MainMenu");
    }
}
