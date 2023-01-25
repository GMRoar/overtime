using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public CharacterController fpsController;
    private Vector3 movementVelocity;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    private bool isGrounded;
    public static float movementSpeed = 2.0f;
    private float gravity = -9.81f;



    // Update is called once per frame
    void Update()
    {
        // Control Setups
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        bool sprint = Input.GetKey(KeyCode.LeftShift);
        // Move the character
        Vector3 move = transform.right * x + transform.forward * z;
        fpsController.Move(move * Time.deltaTime * movementSpeed);

        // Physics Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && movementVelocity.y < 0)
        {
            movementVelocity.y = 0f;
        }
        // Perform Gravity
        movementVelocity.y += gravity * Time.deltaTime;
        fpsController.Move(movementVelocity * Time.deltaTime);

        // Sprint
        if (sprint)
        {
            movementSpeed = 8f;
        }
        else
        {
            movementSpeed = 4f;
        }
    }
}
