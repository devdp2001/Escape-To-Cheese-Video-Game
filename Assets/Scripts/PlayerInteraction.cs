using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Created By: Sophia Wu
/// Date:       10/25/2023
///     Implementation for handling player interaction with interactable objects.
///     If player is hovering over an interactable object, show crosshair and
///     information on player screen to show object can be interacted with.
///     Handle actions for different objects. Door is currently implemented.
///     
///     Place on player object.

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask mask;
    GameObject crosshair;
    public GameObject interactPrompt;
    public GameObject winMenu;
    RaycastHit hit;

    bool interacting;

    void Start()
    {
        //crosshair = GameObject.Find("Crosshair");
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        interacting = Physics.Raycast(ray, out hit, rayDistance, mask);

        // toggling player crosshair and interaction prompt 
        if (interacting)
        {
            //crosshair.SetActive(true);
            interactPrompt.SetActive(true);
        }
        else
        {
            //crosshair.SetActive(false);
            interactPrompt.SetActive(false);
        }

        // opening and closing door
        // interacting with cheese
        if (interacting && Input.GetKeyDown(KeyCode.E))
        {
            if (hit.collider.GetComponent<Door>() != null)
            {
                Door door = hit.collider.GetComponent<Door>();
                door.DoorToggling();
            }
            else {
                winMenu.SetActive(true);
            }
        }
    }
}
