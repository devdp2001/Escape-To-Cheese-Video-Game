using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class NewInputManager : MonoBehaviour
{
    PlayerControl playercontrols;
    AnimatorManager animatormanager;
    [SerializeField]
    Vector2 input;
    Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;
    public float verticalInput;
    public float horizontalInput;
    public bool jump_input;
    float moveAmount;
    float cameraSpeed; 
    public bool cameraToggle;
    // Start is called before the first frame update
    void Start(){
        cameraToggle = PlayerPrefs.GetInt("ToggleCam") == 1;
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
        cameraSpeed = 1f; 
    }
    void OnEnable()
    {
        if(playercontrols == null)
        {
            playercontrols = new PlayerControl();

            playercontrols.Player.Movement.performed += i => input = i.ReadValue<Vector2>();
            playercontrols.Player.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            playercontrols.Player.Jump.performed += input => jump_input = true;
        }

        playercontrols.Enable();
    }
    void ArrowHandle(){
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cameraInputY = cameraSpeed; 
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            cameraInputX = 0; 
            cameraInputY = 0; 
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            cameraInputY = -1 * cameraSpeed; 
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            cameraInputX = 0; 
            cameraInputY = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            cameraInputX = -1 * cameraSpeed; 
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            cameraInputX = 0; 
            cameraInputY = 0; 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            cameraInputX = cameraSpeed; 
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            cameraInputX = 0; 
            cameraInputY = 0; 
        }
    }  
    private void Awake()
    {
        animatormanager = GetComponent<AnimatorManager>();
    }

    void OnDisable()
    {
        playercontrols.Disable();
    }
    public void toggleButton(bool toggle){
        cameraToggle = toggle; 
        PlayerPrefs.SetInt("ToggleCam",cameraToggle ? 1 : 0);
    }
    void HandleMovementInput()
    {
        verticalInput = input.y;
        horizontalInput = input.x;
        if (!cameraToggle){
            cameraInputX = cameraInput.x;
            cameraInputY = cameraInput.y;
        }
        else{
            ArrowHandle();
        }
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatormanager.UpdateAnimatorValues(0, moveAmount);
    }
    
    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleJumpingInput();
        //Need to add jump
    }

    private void HandleJumpingInput()
    {
        jump_input = false;
    }
}
