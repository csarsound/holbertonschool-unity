using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;

    private bool isInverted = false;

    private void Start()
    {
        // Recuperar el valor guardado del toggle y asignarlo al estado actual
        isInverted = PlayerPrefs.GetInt("IsInverted", 0) == 1;
        invertYToggle.isOn = isInverted;
    }

    public void Apply()
    {
        // Guardar el estado actual del toggle en PlayerPrefs
        isInverted = invertYToggle.isOn;
        PlayerPrefs.SetInt("IsInverted", isInverted ? 1 : 0);

        ReturnToPreviousScene();
    }

    public void Back()
    {
        ReturnToPreviousScene();
    }

    private void ReturnToPreviousScene()
    {
        // Obtener el índice de la escena anterior en la secuencia de escenas del juego
        int previousSceneIndex = PlayerPrefs.GetInt("PreviousSceneIndex", 0);
        SceneManager.LoadScene(previousSceneIndex);
    }
}
