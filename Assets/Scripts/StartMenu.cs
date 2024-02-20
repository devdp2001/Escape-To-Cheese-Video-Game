using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("GAME STARTED!");
        SceneManager.LoadScene(1);
    }

    public void QuitGame() 
    {
        Debug.Log("GAME QUIT!");
        Application.Quit();
    }
}