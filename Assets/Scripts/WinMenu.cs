using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// Created By: Sophia Wu
/// Date:       12/303/2023
///     Handling of buttons on the win screen.

public class WinMenu : MonoBehaviour
{
    public GameObject winMenu;
    CameraManager cameraManager;
    public static bool isPaused;

    [SerializeField] float rayDistance;
    [SerializeField] LayerMask mask;
    public GameObject interactPrompt;
    RaycastHit hit;

    bool interacting;

    void Start()
    {
        //crosshair = GameObject.Find("Crosshair");
        //pauseMenu = new GameObject();
        cameraManager = FindAnyObjectByType<CameraManager>();
        winMenu.SetActive(false);
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
            winGame();

        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void winGame()
    {
        Cursor.lockState = CursorLockMode.None;
        cameraManager.isPaused = true;
        winMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("the game is paused!!!");

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }
}
