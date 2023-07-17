using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip footstepsRunningGrass;
    public AudioClip footstepsRunningRock;
    public AudioClip landingGrass;
    public AudioClip landingRock;

    private AudioSource audioSource;
    public AudioMixerGroup landingAudioGroup;
    public AudioMixerGroup runningAudioGroup;
    public Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool landingActive = animator.GetCurrentAnimatorStateInfo(0).IsTag("FallingImpact");

        if (landingActive)
        {
            audioSource.outputAudioMixerGroup = landingAudioGroup;
            // Obtener el tipo de suelo debajo del jugador
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
            {
                // Reproducir el sonido de los pasos según el tipo de suelo
                if (hit.collider.CompareTag("Grass"))
                {
                    audioSource.clip = landingGrass;
                }
                else if (hit.collider.CompareTag("Rock"))
                {
                    audioSource.clip = landingRock;
                }

                // Reproducir el sonido de los pasos en bucle
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Running"))
        {
            audioSource.outputAudioMixerGroup = runningAudioGroup;
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
