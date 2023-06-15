using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle toggle;

    private void Start()
    {
        // Recuperar el valor guardado del toggle y asignarlo al estado actual
        toggle.isOn = PlayerPrefs.GetInt("IsInverted", 0) == 1;
    }

    public void OnToggleValueChanged()
    {
        // Guardar el estado actual del toggle en PlayerPrefs
        PlayerPrefs.SetInt("IsInverted", toggle.isOn ? 1 : 0);
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(previousSceneIndex);
    }
}
