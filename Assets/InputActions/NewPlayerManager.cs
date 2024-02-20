using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerManager : MonoBehaviour
{
    NewInputManager inputManager;
    NewPlayerMovement motion;
    CameraManager cameraManager;
    void Awake()
    {
        inputManager = GetComponent<NewInputManager>();
        cameraManager = FindAnyObjectByType<CameraManager>();
        motion = GetComponent<NewPlayerMovement>();
    }

    void FixedUpdate() //A better call to handle rigidbodies
    {
        motion.HandleAllMovement();
    }

    void Update()
    {
        inputManager.HandleAllInputs();
    }

    void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
    }
}
