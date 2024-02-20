using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Created By: Jaysson Solano
///     Implemeted feature to toggle through different camera views (basic, top-down, over-the-shoulder)
///     and toggle player transparency.
/// 
/// Modified By: Sophia Wu 
/// Date:        10/30/2023
///     Modified behavior to toggle camera style using F1, F2, and F3.
///     Modified behavior to toggle player stealth (transparency) using 1.


public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Renderer playerCapsule;
    public Rigidbody rb;

    public float rotationSpeed;

    public Transform combatLookAt;

    public GameObject thirdPersonCam;
    public GameObject combatCam;
    public GameObject topDownCam;

    public CameraStyle currentStyle;

    public Material opaque;
    public Material transparent;
    private bool stealthed;

    public enum CameraStyle
    {
        Basic,
        Combat,
        Topdown
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        stealthed = false;
    }

    private void Update()
    {
        // switch styles
        //if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCameraStyle(CameraStyle.Basic);
        //if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCameraStyle(CameraStyle.Combat);
        //if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchCameraStyle(CameraStyle.Topdown);
        //if (Input.GetKeyDown(KeyCode.Alpha4)) SwitchMaterial(opaque);
        //if (Input.GetKeyDown(KeyCode.Alpha5)) SwitchMaterial(transparent);

        // F1 - basic, F2 - combat, F3 - topdown
        // 1  - toggle player transparency/stealth
        if (Input.GetKeyDown(KeyCode.F1)) SwitchCameraStyle(CameraStyle.Basic);
        if (Input.GetKeyDown(KeyCode.F2)) SwitchCameraStyle(CameraStyle.Combat);
        if (Input.GetKeyDown(KeyCode.F3)) SwitchCameraStyle(CameraStyle.Topdown);
        if (Input.GetKeyDown(KeyCode.Alpha1)) { 
            if (!stealthed) SwitchMaterial(opaque);
            else SwitchMaterial(transparent);
        } 


        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // roate player object
        if(currentStyle == CameraStyle.Basic || currentStyle == CameraStyle.Topdown)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

        else if(currentStyle == CameraStyle.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
        }
    }

    private void SwitchCameraStyle(CameraStyle newStyle)
    {
        combatCam.SetActive(false);
        thirdPersonCam.SetActive(false);
        topDownCam.SetActive(false);

        if (newStyle == CameraStyle.Basic) thirdPersonCam.SetActive(true);
        if (newStyle == CameraStyle.Combat) combatCam.SetActive(true);
        if (newStyle == CameraStyle.Topdown) topDownCam.SetActive(true);

        currentStyle = newStyle;
    }

    void SwitchMaterial(Material mat)
    {
        playerCapsule.material = mat;
        stealthed = !stealthed;
    }
}
