using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isRunning = false; 
    public Transform groundCheck;
    public LayerMask groundMask;
    public float playerSpeed = 10f;
    public float playerJumpHeight = 5f;
    public float gravity = -9.81f;
    public Transform fallCheck;
    public Transform ty;
    public Animator animator; //Reference animator Ty

    private Vector3 movement;
    public bool isFallingFlatImpact = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si está dentro de la Sub-State Machine "FallingDown"
        bool isInFallingDown = animator.GetCurrentAnimatorStateInfo(0).IsTag("FallingDown");

        // Actualizar el booleano "isFallingFlatImpact" en función de si está en "FallingDown"
        isFallingFlatImpact = isInFallingDown;


        FallFromWorld();

        // Restore value of Velocity
        if (IsGrounded() && playerVelocity.y < 0)
        {
            playerVelocity.y = -2;
            // Activar la animación "Falling Flat Impact"
            animator.SetTrigger("FallingFlatImpact");
            // Controlar el estado de la animación "Falling Flat Impact"
        }

        Movements();
        Jump();

        // Si no hay un objetivo y no está ocurriendo la animación "Falling Flat Impact", aplicar el movimiento del jugador
        if (!isFallingFlatImpact)
        {
            characterController.Move(movement * playerSpeed * Time.deltaTime);
        }
    }

    void Movements()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

    if (x != 0f || z != 0f)
    {
        // Calcula el ángulo de rotación basado en las flechas del teclado
        float targetAngle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;

        // Rota solo el modelo del personaje al ángulo deseado
        ty.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }

         isRunning = (x != 0f || z != 0f);

        // Movement Streight
        movement = transform.right * x + transform.forward * z;

        if (isRunning)
        {
            // Reproducir la animación "Running"
            animator.SetBool("Running", true);
        }
        else
        {
            // Detener la animación "Running"
            animator.SetBool("Running", false);
        }
    }

    // Player jump
    void Jump()
    {
        // Player jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerVelocity.y = Mathf.Sqrt(playerJumpHeight * -2f * gravity);
            // Activate Animation Jump
            animator.SetTrigger("Jump");
        }

        // Apply gravity to player
        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    // Check if player is grounded
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
    }

    //Change the position if player fell
    void FallFromWorld()
    {
        if (characterController.transform.position.y <= fallCheck.position.y)
        {
            animator.SetTrigger("Falling");
            characterController.enabled = false;
            characterController.transform.position = new Vector3(0, 10, 0);
            characterController.enabled = true;
        }

        characterController.velocity.Set(0,0,0);
    }
}
