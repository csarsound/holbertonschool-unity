using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float mouseSensitivity = 100f;
    public bool isInverted = false; // Booleano para invertir el eje Y

    private Vector3 offset; 

    private void Start()
    {
        // Recuperar el valor guardado del toggle
        isInverted = PlayerPrefs.GetInt("IsInverted", 0) == 1;

        // Calcular el desplazamiento inicial entre la cámara y el jugador
        offset = transform.position - playerTransform.position;

    }

    void LateUpdate()
    {
        // Obtener el movimiento horizontal del trackpad
        float trackpadInput = Input.GetAxis("Mouse X");

        // Obtener el movimiento vertical del trackpad y aplicar la inversión
        float verticalInput = Input.GetAxis("Mouse Y");
        if (isInverted)
        {
            verticalInput *= -1f;
        }

        // Rotar la cámara en función del movimiento del trackpad
        Vector3 rotation = new Vector3(verticalInput, trackpadInput, 0) * mouseSensitivity * Time.deltaTime;
        transform.eulerAngles += rotation;
    }
}
