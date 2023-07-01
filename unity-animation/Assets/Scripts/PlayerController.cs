using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float playerSpeed = 10f;
    public float playerJumpHeight = 5f;
    public float gravity = -9.81f;
    public Transform fallCheck;

    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        FallFromWorld();

        // Restore value of Velocity
        if (IsGrounded() && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        Movements();
        Jump();
            // Si no hay un objetivo, simplemente aplicar el movimiento del jugador
            characterController.Move(movement * playerSpeed * Time.deltaTime);
    }

    void Movements()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Movement Streight
        movement = transform.right * x + transform.forward * z;
    }

    // Player jump
    void Jump()
    {
        // Player jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerVelocity.y = Mathf.Sqrt(playerJumpHeight * -2f * gravity);
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
            characterController.enabled = false;
            characterController.transform.position = new Vector3(0, 10, 0);
            characterController.enabled = true;
        }
        characterController.velocity.Set(0,0,0);
    }
}
