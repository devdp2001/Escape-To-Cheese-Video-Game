using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Created By: Sophia Wu
// Date:       11/15/2023
//             Used to trigger tutorial popups after player pass
//             certain areas.

public class TutorialTrigger : MonoBehaviour
{
    public GameObject newText;
    public GameObject prevText;

    // Start is called before the first frame update
    void Start()
    {
        newText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            prevText.SetActive(false);
            newText.SetActive(true);
        }
    }
}
