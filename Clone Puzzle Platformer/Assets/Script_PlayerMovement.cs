using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // The player's movement speed
    public float jumpForce = 10f; // The force applied to the player when they jump
    public float gravity = -9.81f; // The gravity applied to the player
    public float groundDistance = 0.7f; // The distance from the player's center to the ground

    public LayerMask groundMask; // The layer mask of the ground

    private CharacterController controller; // The CharacterController component attached to the player

    private bool isGrounded; // Whether or not the player is grounded
    private Vector3 velocity; // The player's velocity

    //rotate player
    private bool isFacingRight = true;

    //sfx
    public AudioClip ac_jumpSFX;
    private AudioSource audioSource;



    private void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the player's CharacterController component
        //create audio source component to be added
        audioSource = gameObject.AddComponent<AudioSource>();
        //as_jumpSFX.playOnAwake = false;
        //set the audio clip to play
        
        

    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get the player's horizontal input


        

        Vector3 movement = new Vector3(horizontal, 0f, 0f); // Create a movement vector

        controller.Move(movement * speed * Time.deltaTime); // Move the player based on the movement vector

        // Calculate the end position of the line
        Vector3 endPosition = transform.position - transform.up * groundDistance;
        // Draw a line from the object's position to the end position
        Debug.DrawLine(transform.position, endPosition, Color.green);

        // Cast a ray downwards from the bottom of the GameObject, and check if it hits the ground layer
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance, groundMask))
        {
            // The ray hit the ground layer, so the GameObject is grounded
            isGrounded = true;
            if (isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f; // Apply a small downward force to the player when they are grounded
            }

            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Calculate the jump velocity based on the jump force and gravity
                audioSource.clip = ac_jumpSFX;
                audioSource.Play();
            }
        }
        else
        {
            // The ray did not hit the ground layer, so the GameObject is not grounded
            isGrounded = false;
        }

        velocity.y += gravity * Time.deltaTime; // Apply gravity to the player's velocity

        controller.Move(velocity * Time.deltaTime); // Move the player based on the velocity


        if (horizontal > 0 && !isFacingRight)
        {
            TurnAround();

        }
        else if (horizontal < 0 && isFacingRight)
        {
            TurnAround();
        }

        //Debug.Log(horizontal);
    }

    void TurnAround()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

}
