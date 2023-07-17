using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;

    private bool isInverted = false;
    public AudioMixer audioMixer;
    public Slider bgmSlider;
    public string volumeParameter = "BGM";

    private void Start()
    {
        // Obtener el valor guardado del volumen desde PlayerPrefs
        float savedVolume = PlayerPrefs.GetFloat(volumeParameter, 1f);

        // Establecer el valor del slider al valor guardado
        bgmSlider.value = savedVolume;

        // Actualizar el volumen del audio de fondo
        SetBGMVolume(savedVolume);

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

     public void OnSliderValueChanged()
    {
        // Obtener el valor actual del slider
        float sliderValue = bgmSlider.value;
        // Actualizar el volumen del audio de fondo
        SetBGMVolume(sliderValue);
        // Guardar el valor del volumen en PlayerPrefs
        PlayerPrefs.SetFloat(volumeParameter, sliderValue);
    }

    private void SetBGMVolume(float volume)
    {
        // Convertir el valor del slider en una escala lineal desde -80 dB (silenciado) hasta 0 dB (volumen máximo)
        float dB = Mathf.Lerp(-80f, 0f, volume);
        // Establecer el volumen en el parámetro del Audio Mixer
        audioMixer.SetFloat(volumeParameter, dB);
    }
}
