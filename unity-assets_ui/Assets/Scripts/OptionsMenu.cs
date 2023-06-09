using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu"); // Cargar la escena anterior
    }
}
