using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToStartMenu()
    {
        ResetAudio(0);
        SceneManager.LoadScene("StartMenu");
        
    }


    public void TestIfClicked()
    {
        Debug.Log("clicked!");
    }

    private void ResetAudio(int sceneIdx)
    {
        if (sceneIdx == 0)
        {
            Destroy(GameObject.Find("The_World_Sleeps"));
            Debug.Log("here" + GameObject.Find("The_World_Sleeps"));
        }
    }


}
