using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public Transform groundPlacement;
    NewInputManager inputManager;
    public float fallingSpeed;
    public LayerMask groundLayer;
    Vector3 moveDirection;
    Transform maincam;
    Rigidbody rb;
    public bool isGrounded;
    public float movementSpeed;
    public float rotationSpeed;
    void HandleMovement()
    {
        moveDirection = maincam.forward * inputManager.verticalInput; //movement for going forward and back since values will be 1/-1
        moveDirection = moveDirection + (maincam.right * inputManager.horizontalInput); //pemdas
        moveDirection.Normalize(); //move consistently
        moveDirection.y = 0;
        moveDirection *= movementSpeed;

        Vector3 movementVelocity  = moveDirection; //applies movement
        rb.velocity = movementVelocity;
    }

    public void HandleAllMovement()
    {
        HandleFallingAndLanding();
        HandleMovement();
        HandleRotation();
    }
    void HandleRotation()
    {
        Vector3 targetDirection = maincam.forward * inputManager.verticalInput;
        targetDirection = targetDirection + (maincam.right * inputManager.horizontalInput); //pemdas
        targetDirection.Normalize();
        targetDirection.y = 0;

        if(targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    void HandleFallingAndLanding()
    {
        RaycastHit hit;
        if(!isGrounded)
        {    
            rb.AddForce(Vector3.down * 100f); //Falling force with a speed multiplier
        }

        if(!Physics.SphereCast(groundPlacement.position, 0.2f, Vector3.down, out hit))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    void Start()
    {
        inputManager = GetComponent<NewInputManager>();
        rb = GetComponent<Rigidbody>();
        maincam = Camera.main.transform;
    }
}
