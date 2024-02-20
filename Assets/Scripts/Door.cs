using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Created By: Sophia Wu
/// Date:       10/25/2023
///     Implementation for handling when player interacts with door.
///     When player interacts with door, toggle animation on for door.
///     
/// Modified By: Sophia Wu
/// Date:        10/29/2023
///     Implemented sound when door is opened or closed.

public class Door : MonoBehaviour
{
    GameObject door;
    bool toggling;
    [SerializeField] AudioClip open, close;

    private void Start()
    {
        //door = GameObject.Find("DoorParent");
        door = gameObject.transform.parent.gameObject.transform.parent.gameObject;
    }

    public void DoorToggling() {
        toggling = !toggling;
        door.GetComponent<Animator>().SetBool("DoorToggle", toggling);
        print("Interacting with door");

        if (toggling)
        {
            door.GetComponent<AudioSource>().PlayOneShot(open);
        }
        else 
        {
            door.GetComponent<AudioSource>().PlayOneShot(close);
        }
    }
}
