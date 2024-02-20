using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public bool isPaused;
    public LayerMask collisionLayer; //NOTICE: Attach this layer to any gameobject you want the camera to collide with
    public Transform cameraPivot; //The empty pivot object attached to camera
    public Transform cameraTransform;
    Transform targetTransform; 
    NewInputManager inputManager;
    Vector3 cameraFollowVelocity = Vector3.zero;
    Vector3 cameraVectorPosition;
    public float cameraFollowSpeed = 0.2f; //A good starting speed is 0.2f change when needed;
    public float cameraLookSpeed = 2; //ditto
    public float cameraPivotSpeed = 2; //ditto
    public float cameraCollisionRadius = 0.2f; //di-di-ditto
    public float cameraCollisionOffset = 0.2f; //^^
    public float minimumCollisionOffSet = 0.2f; //you get the idea
    float defaultPosition;

    public float lookAngle; //looking up and down
    public float pivotAngle; //looking left and right

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        inputManager = FindObjectOfType<NewInputManager>();
        targetTransform = FindObjectOfType<NewPlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }
    void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed); //Follows player
        transform.position = targetPosition;
    }

    void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, -15f, 35f);


        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero; //reuse the variable because why not
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    public void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if(Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayer))
        {
            Debug.Log("hit");
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition =- (distance - cameraCollisionOffset);
        }
        

        if(Mathf.Abs(targetPosition) < minimumCollisionOffSet)
        {
            targetPosition = targetPosition - minimumCollisionOffSet;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }

    public void HandleAllCameraMovement() //save yourself the headache and just do it all at once
    {
        if(!isPaused)
        {
            FollowTarget();
            RotateCamera();
            HandleCameraCollisions();
        }
    }
}
