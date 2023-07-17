using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioClip footstepsRunningGrass;
    public AudioClip footstepsRunningRock;

    private AudioSource audioSource;
    public Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Running"))
        {
            // Obtener el tipo de suelo debajo del jugador
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
            {
                // Reproducir el sonido de los pasos según el tipo de suelo
                if (hit.collider.CompareTag("Grass"))
                {
                    audioSource.clip = footstepsRunningGrass;
                }
                else if (hit.collider.CompareTag("Rock"))
                {
                    audioSource.clip = footstepsRunningRock;
                }

                // Reproducir el sonido de los pasos en bucle
                if (!audioSource.isPlaying)
                {
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }
        }
        else
        {
            // Detener la reproducción de los sonidos de los pasos cuando el jugador deja de correr
            audioSource.loop = false;
            audioSource.Stop();
        }
    }
}
