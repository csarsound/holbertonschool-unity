using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    
    // Update is called once per frame
    void Update()
    {
        // Obtener el movimiento horizontal del trackpad
        float trackpadInput = Input.GetAxis("Mouse X");
        
        // Rotar la cámara en función del movimiento del trackpad
        transform.Rotate(Vector3.up * trackpadInput * mouseSensitivity * Time.deltaTime);
    }
}
