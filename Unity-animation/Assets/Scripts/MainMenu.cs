using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        string sceneName = "Level" + level.ToString("00"); // Genered the Name of the Scene
        SceneManager.LoadScene(sceneName); // Charge the scene
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void ExitButton()
    {
        Debug.Log("Exited"); // Imprime "Exited" en la consola
        Application.Quit(); // Cierra el juego
    }
}
